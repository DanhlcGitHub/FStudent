using FStudent.DTO;
using FStudent.DTOMY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FStudent.DAO
{
    public class CustomDAO
    {
        public int GetCurrentSemesterID(String date)
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
        public List<SectionSchedule> GetListSectionScheduleInWeekByStudentBySemester(string datePeriod, int semesterID, string studentID)
        {
            CustomDAO dao = new CustomDAO();
            List<SectionSchedule> finalList = new List<SectionSchedule>();
            List<StudentTranscript> StudentTranscriptList = dao.GetStudentTranscriptByStudentID(studentID);

            for (int i = 0; i < StudentTranscriptList.Count; i++)
            {
                StudentTranscript st = StudentTranscriptList[i];
                Section sec = dao.GetSectionByID(st.SectionID);
                if (sec.SemesterBelong == semesterID)
                {
                    List<SectionSchedule> subList = dao.GetListSectionScheduleInPeriod(datePeriod, st.SectionID);
                    foreach (var item in subList)
                    {
                        finalList.Add(item);
                    }
                }
            }
            return finalList;
        }

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
        // sectionID; status; credit; GPA;semesterID; semesterName;
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

        public List<SemesterTranscriptModel> GetAllSectionOfSpecificStudentService(String studentID)
        {
            List<Object> topList = new CustomDAO().spGetAllSectionOfSpecificStudent(studentID);
            List<SemesterTranscriptModel> SemesterTranscriptModelList = new List<SemesterTranscriptModel>();

            if (topList != null && topList.Count != 0)
            {
                // put each item into SemesterTranscriptModelList
                foreach (var item in topList)
                {
                    int SemesterID = (int)item.GetType().GetProperty("SemesterID").GetValue(item, null);

                    String SemesterName =
                        (String)item.GetType().GetProperty("SemesterName").GetValue(item, null);

                    if (!isSemesterAlreadyExist(SemesterTranscriptModelList, SemesterID))
                    {
                        SemesterTranscriptModel s = new SemesterTranscriptModel();
                        s.semesterID = SemesterID;
                        s.semesterName = SemesterName;
                        SemesterTranscriptModelList.Add(s);
                    }
                }

                // travel throught SemesterTranscriptModelList to put sub SectionTranscriptModel List
                foreach (var semesterTranscriptModel in SemesterTranscriptModelList)
                {
                    List<SectionTranscriptModel> secList = new List<SectionTranscriptModel>();
                    foreach (var item in topList)
                    {
                        int SemesterID =
                        (int)item.GetType().GetProperty("SemesterID").GetValue(item, null);

                        if (semesterTranscriptModel.semesterID == SemesterID)
                        {
                            string SectionID =
                                (String)item.GetType().GetProperty("SectionID").GetValue(item, null);

                            string LearningStatus =
                                (String)item.GetType().GetProperty("LearningStatus").GetValue(item, null);

                            int Credit =
                                (int)item.GetType().GetProperty("Credit").GetValue(item, null);

                            double AverageGrade =
                                (double)item.GetType().GetProperty("AverageGrade").GetValue(item, null);

                            SectionTranscriptModel secModel = new SectionTranscriptModel();
                            secModel.credit = Credit;
                            secModel.GPA = AverageGrade;
                            secModel.sectionID = SectionID;
                            secModel.status = LearningStatus;
                            secList.Add(secModel);
                        }
                    }
                    semesterTranscriptModel.sectionTranscriptModel = secList;
                    semesterTranscriptModel.CalculateGPAAndCredit();
                }
            }
            return SemesterTranscriptModelList;
        }

        public bool isSemesterAlreadyExist(List<SemesterTranscriptModel> list, int semesterID)
        {
            foreach (var item in list)
            {
                if (item.semesterID == semesterID) return true;
            }
            return false;
        }
    }
}