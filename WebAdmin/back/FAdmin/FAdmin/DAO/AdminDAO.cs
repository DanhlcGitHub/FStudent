using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FAdmin.DTO;

namespace FAdmin.DAO
{
    class AdminDAO
    {
        public List<Admin> GetAdminList()
        {
            List<Admin> AdminList = new List<Admin>();
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Select * from Admin", con);

            con.Open();
            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Admin c = new Admin()
                {
                    AdminID = rdr["AdminID"].ToString(),
                    AdminName = rdr["AdminName"].ToString(),
                    Password = rdr["Password"].ToString()
                };
                AdminList.Add(c);
            }
            con.Close();
            return AdminList;
        }

        public bool IsAdminExist(string adminID)
        {
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Select * from Admin where AdminID = (@ID)", con);

            SqlParameter ParameterStudentID = new SqlParameter();
            ParameterStudentID.ParameterName = "@ID";
            ParameterStudentID.Value = adminID;

            cmd.Parameters.Add(ParameterStudentID);

            con.Open();
            var rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                return true;
            }
            con.Close();
            return false;
        }

        public bool DeleteAdmin(string adminID)
        {
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Delete from Admin where AdminID = (@ID)", con);

            cmd.Parameters.AddWithValue("@ID", adminID);

            con.Open();
            int row = -1;
            row = cmd.ExecuteNonQuery();
            con.Close();
            return row < 0 ? false : true;
        }

        public bool InsertAdmin(string AdminID, string AdmintName, string Password)
        {
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("INSERT INTO Admin (AdminID,AdminName,Password) "
            + "VALUES (@AdminID,@AdminName,@Password)", con);

            cmd.Parameters.AddWithValue("@AdminID", AdminID);
            cmd.Parameters.AddWithValue("@AdminName", AdmintName);
            cmd.Parameters.AddWithValue("@Password", Password);

            con.Open();
            int row = -1;
            row = cmd.ExecuteNonQuery();
            con.Close();
            return row < 0 ? false : true;
        }

        public bool UpdateAdmin(string AdminID, string AdmintName, string Password)
        {
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Update Admin set AdminName = (@AdminName) , "
                + "Password = (@Password) where AdminID = (@AdminID)", con);

            cmd.Parameters.AddWithValue("@AdminID", AdminID);
            cmd.Parameters.AddWithValue("@AdminName", AdmintName);
            cmd.Parameters.AddWithValue("@Password", Password);

            con.Open();
            int row = -1;
            row = cmd.ExecuteNonQuery();
            con.Close();
            return row < 0 ? false : true;
        }
    }
}
