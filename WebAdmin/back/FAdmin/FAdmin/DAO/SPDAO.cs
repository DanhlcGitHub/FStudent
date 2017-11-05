using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using FAdmin.DTO;


namespace FAdmin.DAO
{
    class SPDAO
    {
        public int CalculateTotalCreditByStudentID(string studentID)
        {
            int totalCredit = 0;
            using (SqlConnection con = BaseDAO.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("spCalculateTotalCreditByStudentID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentID", studentID);
                con.Open();
                var rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    int.TryParse(rdr["totalCredit"].ToString(), out totalCredit);
                }
            }
            return totalCredit;
        }

        public int CalculateTotalCreditByStudentID1(string studentID)
        {
            int totalCredit = 0;
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = BaseDAO.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("spCalculateTotalCreditByStudentID1", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentID", studentID);
                SqlParameter outputParameter = new SqlParameter();
                outputParameter.ParameterName = "@totalCredit";
                outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                outputParameter.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outputParameter);

                con.Open();
                cmd.ExecuteNonQuery();

                string totalCreditStr = outputParameter.Value.ToString();
                int.TryParse(totalCreditStr, out totalCredit);
            }
            return totalCredit;
        }

        public float CalculateAverageGradeByTranscriptID(int transcriptID)
        {
            float AverageGrade = 0;
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = BaseDAO.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("spCalculateAverageGradeByTranscriptID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TranscriptID", transcriptID);
                SqlParameter outputParameter = new SqlParameter();
                outputParameter.ParameterName = "@AverageGrade";
                outputParameter.SqlDbType = System.Data.SqlDbType.Float;
                outputParameter.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outputParameter);

                con.Open();
                cmd.ExecuteNonQuery();

                string AverageGradeStr = outputParameter.Value.ToString();
                float.TryParse(AverageGradeStr, out AverageGrade);
            }
            return AverageGrade;
        }

        public List<Object> FindTop10StudentInSemester(int semester)
        {
            List<Object> topList = new List<Object>();
            using (SqlConnection con = BaseDAO.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("spFindTop10Student", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Semester", semester);
                con.Open();
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Object c = new
                    {
                        StudentCode = rdr["StudentCode"].ToString(),
                        SemesterAverageGrade = rdr["SemesterAverageGrade"].ToString()
                    };
                    topList.Add(c);
                }
            }
            return topList;
        }

        public List<SectionSchedule> ListWeeklyScheduleOfSpecificStudent(string studentID, DateTime from, DateTime to)
        {
            List<SectionSchedule> scheduleList = new List<SectionSchedule>();
            using (SqlConnection con = BaseDAO.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("spListWeeklyScheduleOfSpecificStudent", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentID", studentID);
                cmd.Parameters.AddWithValue("@FromDate", from);
                cmd.Parameters.AddWithValue("@ToDate", to);
                con.Open();
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SectionSchedule c = new SectionSchedule
                    {
                        SectionScheduleID = Convert.ToInt32(rdr["SectionScheduleID"].ToString()),
                        SectionID = rdr["SectionID"].ToString(),
                        Date = Convert.ToDateTime(rdr["Date"].ToString()),
                        Slot = Convert.ToInt32(rdr["Slot"].ToString()),
                        Duration = Convert.ToInt32(rdr["Duration"].ToString()),
                        Room = rdr["Room"].ToString(),
                    };
                    scheduleList.Add(c);
                }
            }
            return scheduleList;
        }

        public List<StudentTranscript> FindAllCourseByStudentID(string studentID)
        {
            List<StudentTranscript> StudentTranscriptList = new List<StudentTranscript>();
            using (SqlConnection con = BaseDAO.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("spFindAllCourseByStudentID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentID", studentID);
                con.Open();
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    StudentTranscript c = new StudentTranscript()
                    {
                        TranscriptID = Convert.ToInt32(rdr["TranscriptID"].ToString()),
                        StudentCode = rdr["StudentCode"].ToString(),
                        SectionID = rdr["SectionID"].ToString(),
                        AverageGrade = float.Parse(rdr["AverageGrade"].ToString()),
                        LearningStatus = rdr["LearningStatus"].ToString(),
                    };
                    StudentTranscriptList.Add(c);
                }
                con.Close();
            }
            return StudentTranscriptList;
        }

        public int GetCurrentSemesterName(String date)
        {
            DateTime currentDate = Convert.ToDateTime(date);
            int SemesterID = -1;
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Select * from Schedule where startDate < (@currentDate) and endDate > (@currentDate)", con);
            cmd.Parameters.AddWithValue("@currentDate", currentDate);

            con.Open();
            var rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                SemesterID = Convert.ToInt32(rdr["SemesterID"].ToString());

            }
            con.Close();
            return SemesterID;
        }

        public List<String> GetAllWeekInSemester(int semesterID)
        {
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();
            List<String> list = new List<string>();
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Select * from Schedule where SemesterID = (@semesterID)", con);
            cmd.Parameters.AddWithValue("@semesterID", semesterID);

            con.Open();
            var rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                startDate = Convert.ToDateTime(rdr["StartDate"].ToString());
                endDate = Convert.ToDateTime(rdr["EndDate"].ToString());
            }
            while (DateTime.Compare(startDate, endDate) < 0)
            {
                String s = startDate.Year + "-" + startDate.Month + "-" + startDate.Day;
                startDate = startDate.AddDays(6);
                s += "," + startDate.Year + "-" + startDate.Month + "-" + startDate.Day;
                list.Add(s);
                startDate = startDate.AddDays(1);
            }
            return list;
        }
        public List<StudentTranscript> GetStudentTranscriptByStudentID(string studentID)
        {
            List<StudentTranscript> StudentTranscriptList = new List<StudentTranscript>();
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Select * from StudentTranscript where StudentCode = (@studentID)", con);
            cmd.Parameters.AddWithValue("@studentID", studentID);

            con.Open();
            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                StudentTranscript c = new StudentTranscript()
                {
                    TranscriptID = Convert.ToInt32(rdr["TranscriptID"].ToString()),
                    StudentCode = rdr["StudentCode"].ToString(),
                    SectionID = rdr["SectionID"].ToString(),
                    LearningStatus = rdr["LearningStatus"].ToString(),
                };
                String avgStr = rdr["AverageGrade"].ToString();
                if (avgStr != null && avgStr != "")
                {
                    c.AverageGrade = Convert.ToDouble(avgStr);
                }
                StudentTranscriptList.Add(c);
            }
            con.Close();
            return StudentTranscriptList;
        }
        public List<SectionSchedule> GetListSectionScheduleInPeriod(string datePeriod, string sectionID)
        {
            String startDateStr = "";
            String endDateStr = "";
            string[] tokens = datePeriod.Split(',');
            if (tokens != null && tokens.Length == 2)
            {
                startDateStr = tokens[0];
                endDateStr = tokens[1];
            }
            DateTime startDate;
            DateTime endDate;

            startDate = Convert.ToDateTime(startDateStr);
            endDate = Convert.ToDateTime(endDateStr);

            List<SectionSchedule> list = new List<SectionSchedule>();
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Select * from SectionSchedule where SectionID = (@sectionID) and Date >= (@startDate) and Date <= (@endDate)", con);
            cmd.Parameters.AddWithValue("@sectionID", sectionID);
            cmd.Parameters.AddWithValue("@startDate", startDate);
            cmd.Parameters.AddWithValue("@endDate", endDate);

            con.Open();
            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                SectionSchedule c = new SectionSchedule()
                {
                    SectionScheduleID = Convert.ToInt32(rdr["SectionScheduleID"].ToString()),
                    SectionID = rdr["SectionID"].ToString(),
                    Date = Convert.ToDateTime(rdr["Date"].ToString()),
                    Slot = Convert.ToInt32(rdr["Slot"].ToString()),
                    Duration = Convert.ToInt32(rdr["Duration"].ToString()),
                    Room = rdr["Room"].ToString(),
                };
                list.Add(c);
            }
            return list;
        }

        public Section GetSectionByID(String SectionNo)
        {
            Section c = null;
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Select * from Section where SectionNo = (@SectionNo)", con);
            cmd.Parameters.AddWithValue("@SectionNo", SectionNo);

            con.Open();
            var rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                c = new Section()
                {
                    SectionNo = rdr["SectionNo"].ToString(),
                    SeatingCapacity = Convert.ToInt32(rdr["SeatingCapacity"].ToString()),
                    StartDate = Convert.ToDateTime(rdr["StartDate"].ToString()),
                    EndDate = Convert.ToDateTime(rdr["EndDate"].ToString()),
                    ProfessorCode = rdr["ProfessorCode"].ToString(),
                    RepresentedSubject = rdr["RepresentedSubject"].ToString(),
                    SemesterBelong = Convert.ToInt32(rdr["SemesterBelong"].ToString()),
                };
            }
            con.Close();
            return c;
        }

        public List<Object> spGetAllSectionOfSpecificStudent(string studentID)
        {
            List<Object> topList = new List<Object>();
            using (SqlConnection con = BaseDAO.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("spGetAllSectionOfSpecificStudent", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentID", studentID);
                con.Open();
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Object c = new
                    {
                        SectionID = rdr["SectionID"].ToString(),
                        LearningStatus = rdr["LearningStatus"].ToString(),
                        Credit = Convert.ToInt32(rdr["Credit"].ToString()),
                        AverageGrade = Convert.ToDouble(rdr["AverageGrade"].ToString()),
                        SemesterID = Convert.ToInt32(rdr["SemesterID"].ToString()),
                        SemesterName = rdr["SemesterName"].ToString(),
                    };
                    topList.Add(c);
                }
            }
            return topList;
        }

    }
}
