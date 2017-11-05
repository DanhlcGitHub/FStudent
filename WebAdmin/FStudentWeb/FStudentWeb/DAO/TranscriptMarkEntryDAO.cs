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
    class TranscriptMarkEntryDAO
    {
        public List<TranscriptMarkEntry> GetAll()
        {
            List<TranscriptMarkEntry> TranscriptMarkEntryList = new List<TranscriptMarkEntry>();
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Select * from TranscriptMarkEntry", con);

            con.Open();
            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                TranscriptMarkEntry c = new TranscriptMarkEntry()
                {
                    EntryID = Convert.ToInt32(rdr["EntryID"].ToString()),
                    TranscriptID = Convert.ToInt32(rdr["TranscriptID"].ToString()),
                    SubjectTeamplateID = Convert.ToInt32(rdr["SubjectTeamplateID"].ToString()),
                    Grade = Convert.ToDecimal(rdr["Grade"].ToString()),
                };
                TranscriptMarkEntryList.Add(c);
            }
            con.Close();
            return TranscriptMarkEntryList;
        }

        public List<TranscriptMarkEntry> FindByTranscriptID(int TranscriptID)
        {
            List<TranscriptMarkEntry> TranscriptMarkEntryList = new List<TranscriptMarkEntry>();
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Select * from TranscriptMarkEntry where TranscriptID = (@TranscriptID)", con);
            cmd.Parameters.AddWithValue("@TranscriptID", TranscriptID);

            con.Open();
            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                TranscriptMarkEntry c = new TranscriptMarkEntry()
                {
                    EntryID = Convert.ToInt32(rdr["EntryID"].ToString()),
                    TranscriptID = Convert.ToInt32(rdr["TranscriptID"].ToString()),
                    SubjectTeamplateID = Convert.ToInt32(rdr["SubjectTeamplateID"].ToString()),
                    Grade = Convert.ToDecimal(rdr["Grade"].ToString()),
                };
                TranscriptMarkEntryList.Add(c);
            }
            con.Close();
            return TranscriptMarkEntryList;
        }

        public bool DeleteTranscriptMarkEntry(int EntryID)
        {
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Delete from TranscriptMarkEntry where EntryID = (@EntryID)", con);

            cmd.Parameters.AddWithValue("@EntryID", EntryID);

            con.Open();
            int row = -1;
            row = cmd.ExecuteNonQuery();
            con.Close();
            return row < 0 ? false : true;
        }

        public bool InsertEntry(int TranscriptID, decimal Grade, int SubjectTeamplateID)
        {
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("INSERT INTO TranscriptMarkEntry (TranscriptID,Grade,SubjectTeamplateID) "
            + "VALUES (@TranscriptID,@Grade,@SubjectTeamplateID)", con);

            cmd.Parameters.AddWithValue("@TranscriptID", TranscriptID);
            cmd.Parameters.AddWithValue("@Grade", Grade);
            cmd.Parameters.AddWithValue("@SubjectTeamplateID", SubjectTeamplateID);

            con.Open();
            int row = -1;
            row = cmd.ExecuteNonQuery();
            con.Close();
            return row < 0 ? false : true;
        }

        public bool UpdateEntry(int EntryID, int TranscriptID, decimal Grade, int SubjectTeamplateID)
        {
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Update TranscriptMarkEntry set TranscriptID = (@TranscriptID), "
                + "Grade = (@Grade), SubjectTeamplateID = (@SubjectTeamplateID) where EntryID = (@EntryID)", con);

            cmd.Parameters.AddWithValue("@TranscriptID", TranscriptID);
            cmd.Parameters.AddWithValue("@SubjectTeamplateID", SubjectTeamplateID);
            cmd.Parameters.AddWithValue("@Grade", Grade);
            cmd.Parameters.AddWithValue("@EntryID", EntryID);

            con.Open();
            int row = -1;
            row = cmd.ExecuteNonQuery();
            con.Close();
            return row < 0 ? false : true;
        }
    }
}
