using FStudentWeb.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FStudentWeb.DAO
{
    class StudentTranscriptDAO
    {
        public List<StudentTranscript> GetAll()
        {
            List<StudentTranscript> StudentTranscriptList = new List<StudentTranscript>();
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Select * from StudentTranscript", con);

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
            return StudentTranscriptList;
        }

        public List<StudentTranscript> FindAllCourseByStudentID(string studentID)
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
                    AverageGrade = float.Parse(rdr["AverageGrade"].ToString()),
                    LearningStatus = rdr["LearningStatus"].ToString(),
                };
                StudentTranscriptList.Add(c);
            }
            con.Close();
            return StudentTranscriptList;
        }

        public bool DeleteTranscript(int TranscriptID)
        {
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Delete from StudentTranscript where TranscriptID = (@TranscriptID)", con);

            cmd.Parameters.AddWithValue("@TranscriptID", TranscriptID);

            con.Open();
            int row = -1;
            row = cmd.ExecuteNonQuery();
            con.Close();
            return row < 0 ? false : true;
        }

        public bool InsertTranscript(string StudentCode, string SectionID, float AverageGrade, string LearningStatus)
        {
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("INSERT INTO StudentTranscript (StudentCode,SectionID,AverageGrade,LearningStatus) "
            + "VALUES (@StudentCode,@SectionID,@AverageGrade,@LearningStatus)", con);

            cmd.Parameters.AddWithValue("@StudentCode", StudentCode);
            cmd.Parameters.AddWithValue("@SectionID", SectionID);
            cmd.Parameters.AddWithValue("@AverageGrade", AverageGrade);
            cmd.Parameters.AddWithValue("@LearningStatus", LearningStatus);

            con.Open();
            int row = -1;
            row = cmd.ExecuteNonQuery();
            con.Close();
            return row < 0 ? false : true;
        }

        public bool UpdateTranscript(int TranscriptID, float AverageGrade, string LearningStatus)
        {
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Update StudentTranscript set AverageGrade = (@AverageGrade) , LearningStatus = (@LearningStatus) "
                + " where TranscriptID = (@TranscriptID)", con);

            cmd.Parameters.AddWithValue("@TranscriptID", TranscriptID);
            cmd.Parameters.AddWithValue("@AverageGrade", AverageGrade);
            cmd.Parameters.AddWithValue("@LearningStatus", LearningStatus);

            con.Open();
            int row = -1;
            row = cmd.ExecuteNonQuery();
            con.Close();
            return row < 0 ? false : true;
        }

        public StudentTranscript FindTranscript(string studentID,string courseID)
        {
            StudentTranscript StudentTranscript = null;
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Select * from StudentTranscript where StudentCode = (@studentID) and SectionID = (@SectionID)", con);
            cmd.Parameters.AddWithValue("@studentID", studentID);
            cmd.Parameters.AddWithValue("@SectionID", courseID);

            con.Open();
            var rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                StudentTranscript c = new StudentTranscript()
                {
                    TranscriptID = Convert.ToInt32(rdr["TranscriptID"].ToString()),
                    StudentCode = rdr["StudentCode"].ToString(),
                    SectionID = rdr["SectionID"].ToString(),
                    AverageGrade = float.Parse(rdr["AverageGrade"].ToString()),
                    LearningStatus = rdr["LearningStatus"].ToString(),
                };
                StudentTranscript = c;
            }
            con.Close();
            return StudentTranscript;
        }

        public bool UpdateTranscriptGrade(int TranscriptID, double AverageGrade)
        {
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Update StudentTranscript set AverageGrade = (@AverageGrade)  "
                + " where TranscriptID = (@TranscriptID)", con);

            cmd.Parameters.AddWithValue("@TranscriptID", TranscriptID);
            cmd.Parameters.AddWithValue("@AverageGrade", AverageGrade);

            con.Open();
            int row = -1;
            row = cmd.ExecuteNonQuery();
            con.Close();
            return row < 0 ? false : true;
        }
    }
}
