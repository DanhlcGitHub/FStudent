using FAdmin.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAdmin.DAO
{
    class SectionDAO
    {
        public List<Section> GetSectionList()
        {
            List<Section> SectionList = new List<Section>();
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Select * from Section", con);

            con.Open();
            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Section c = new Section()
                {
                    SectionNo = rdr["SectionNo"].ToString(),
                    SeatingCapacity = Convert.ToInt32(rdr["SeatingCapacity"].ToString()),
                    StartDate = Convert.ToDateTime(rdr["StartDate"].ToString()),
                    EndDate = Convert.ToDateTime(rdr["EndDate"].ToString()),
                    ProfessorCode = rdr["ProfessorCode"].ToString(),
                    RepresentedSubject = rdr["RepresentedSubject"].ToString(),
                    SemesterBelong = Convert.ToInt32(rdr["SemesterBelong"].ToString()),
                };
                SectionList.Add(c);
            }
            con.Close();
            return SectionList;
        }

        public List<Section> SearchSectionBySubjectID(string SubjectID)
        {
            List<Section> SectionList = new List<Section>();
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Select * from Section where RepresentedSubject = (@SubjectID)", con);
            cmd.Parameters.AddWithValue("@SubjectID", SubjectID);

            con.Open();
            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Section c = new Section()
                {
                    SectionNo = rdr["SectionNo"].ToString(),
                    SeatingCapacity = Convert.ToInt32(rdr["SeatingCapacity"].ToString()),
                    StartDate = Convert.ToDateTime(rdr["StartDate"].ToString()),
                    EndDate = Convert.ToDateTime(rdr["EndDate"].ToString()),
                    ProfessorCode = rdr["ProfessorCode"].ToString(),
                    RepresentedSubject = rdr["RepresentedSubject"].ToString(),
                    SemesterBelong = Convert.ToInt32(rdr["SemesterBelong"].ToString()),
                };
                SectionList.Add(c);
            }
            con.Close();
            return SectionList;
        }

        public bool InsertSection(string SectionNo, int SeatingCapacity, DateTime StartDate, DateTime EndDate, string ProfessorCode, 
            string RepresentedSubject, int SemesterBelong)
        {
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("INSERT INTO Section (SectionNo,SeatingCapacity,StartDate,EndDate,ProfessorCode,RepresentedSubject,SemesterBelong) "
            + "VALUES (@SectionNo,@SeatingCapacity,@StartDate,@EndDate,@ProfessorCode,@RepresentedSubject,@SemesterBelong)", con);

            cmd.Parameters.AddWithValue("@SectionNo", SectionNo);
            cmd.Parameters.AddWithValue("@SeatingCapacity", SeatingCapacity);
            cmd.Parameters.AddWithValue("@StartDate", StartDate);
            cmd.Parameters.AddWithValue("@EndDate", EndDate);
            cmd.Parameters.AddWithValue("@ProfessorCode", ProfessorCode);
            cmd.Parameters.AddWithValue("@RepresentedSubject", RepresentedSubject);
            cmd.Parameters.AddWithValue("@SemesterBelong", SemesterBelong);

            con.Open();
            int row = -1;
            row = cmd.ExecuteNonQuery();
            con.Close();
            return row < 0 ? false : true;
        }

        public bool UpdateSection(string SectionNo, int SeatingCapacity, DateTime StartDate, DateTime EndDate, string ProfessorCode,
            string RepresentedSubject, int SemesterBelong)
        {
            SqlConnection con = BaseDAO.GetConnection();

            SqlCommand cmd = new SqlCommand("Update Section set SeatingCapacity = (@SeatingCapacity) , "
                + "StartDate = (@StartDate),EndDate = (@EndDate),ProfessorCode = (@ProfessorCode),RepresentedSubject = (@RepresentedSubject),"
                + "SemesterBelong = (@SemesterBelong) where SectionNo = (@SectionNo)", con);
            cmd.Parameters.AddWithValue("@SectionNo", SectionNo);
            cmd.Parameters.AddWithValue("@SeatingCapacity", SeatingCapacity);
            cmd.Parameters.AddWithValue("@StartDate", StartDate);
            cmd.Parameters.AddWithValue("@EndDate", EndDate);
            cmd.Parameters.AddWithValue("@ProfessorCode", ProfessorCode);
            cmd.Parameters.AddWithValue("@RepresentedSubject", RepresentedSubject);
            cmd.Parameters.AddWithValue("@SemesterBelong", SemesterBelong);

            con.Open();
            int row = -1;
            row = cmd.ExecuteNonQuery();
            con.Close();
            return row < 0 ? false : true;
        }
    }
}
