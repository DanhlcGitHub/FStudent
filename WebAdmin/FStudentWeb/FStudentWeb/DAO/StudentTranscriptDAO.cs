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
    }
}
