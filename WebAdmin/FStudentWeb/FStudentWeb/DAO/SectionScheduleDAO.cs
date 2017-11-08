using FStudentWeb.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FStudentWeb.DAO
{
    public class SectionScheduleDAO
    {
        public List<SectionSchedule> GetAllSectionScheduleOfSection(string sectionID)
        {
            List<SectionSchedule> SectionScheduleList = new List<SectionSchedule>();
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Select * from SectionSchedule where SectionID = (@sectionID)", con);
            cmd.Parameters.AddWithValue("@sectionID", sectionID);

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
                    Room = rdr["Room"].ToString()
                };
                SectionScheduleList.Add(c);
            }
            con.Close();
            return SectionScheduleList;
        }

        public SectionSchedule GetAllSectionScheduleByID(int sectionScheduleID)
        {
            SectionSchedule ss = null;
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Select * from SectionSchedule where SectionScheduleID = (@sectionScheduleID)", con);
            cmd.Parameters.AddWithValue("@sectionScheduleID", sectionScheduleID);

            con.Open();
            var rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                SectionSchedule c = new SectionSchedule()
                {
                    SectionScheduleID = Convert.ToInt32(rdr["SectionScheduleID"].ToString()),
                    SectionID = rdr["SectionID"].ToString(),
                    Date = Convert.ToDateTime(rdr["Date"].ToString()),
                    Slot = Convert.ToInt32(rdr["Slot"].ToString()),
                    Duration = Convert.ToInt32(rdr["Duration"].ToString()),
                    Room = rdr["Room"].ToString()
                };
                ss = c;
            }
            con.Close();
            return ss;
        }

        public bool UpdateSectionSchedule(SectionSchedule sectionSchedule)
        {
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Update SectionSchedule set SectionID = (@SectionID) , "
                + "Date = (@Date), Slot = (@Slot), Duration = (@Duration), Room = (@Room) where SectionScheduleID = (@SectionScheduleID)", con);

            cmd.Parameters.AddWithValue("@SectionID", sectionSchedule.SectionID);
            cmd.Parameters.AddWithValue("@Date", sectionSchedule.Date);
            cmd.Parameters.AddWithValue("@Slot", sectionSchedule.Slot);
            cmd.Parameters.AddWithValue("@Duration", sectionSchedule.Duration);
            cmd.Parameters.AddWithValue("@Room", sectionSchedule.Room);
            cmd.Parameters.AddWithValue("@SectionScheduleID", sectionSchedule.SectionScheduleID);

            con.Open();
            int row = -1;
            row = cmd.ExecuteNonQuery();
            con.Close();
            return row < 0 ? false : true;
        }
    }
}