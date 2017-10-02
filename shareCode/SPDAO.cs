using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace SWD_ConsoleApplication
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
                    Object c = new {
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
    }
}
