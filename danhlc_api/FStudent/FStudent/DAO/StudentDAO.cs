using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FStudent.DTO;
using System.Data.SqlClient;

namespace FStudent.DAO
{
    class StudentDAO
    {
        public int CheckLogin(string studentID, string password)
        {
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Select * from Student where StudentID = (@ID) and Password = (@Password)", con);

            SqlParameter ParameterStudentID = new SqlParameter();
            ParameterStudentID.ParameterName = "@ID";
            ParameterStudentID.Value = studentID;

            SqlParameter ParameterPassword = new SqlParameter();
            ParameterPassword.ParameterName = "@Password";
            ParameterPassword.Value = password;

            cmd.Parameters.Add(ParameterStudentID);
            cmd.Parameters.Add(ParameterPassword);

            con.Open();
            var rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                return 1;
            }
            con.Close();
            return -1;
        }

        public Student GetStudentByID(string StudentID)
        {
            Student aStudent = null;
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Select * from Student where StudentID = (@ID)", con);

            SqlParameter ParameterStudentID = new SqlParameter();
            ParameterStudentID.ParameterName = "@ID";
            ParameterStudentID.Value = StudentID;

            cmd.Parameters.Add(ParameterStudentID);

            con.Open();
            var rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                aStudent = new Student()
                {
                    StudentID = rdr["StudentID"].ToString(),
                    StudentName = rdr["StudentName"].ToString(),
                    Major = rdr["Major"].ToString(),
                    Address = rdr["Address"].ToString(),
                    Sex = int.Parse(rdr["Sex"].ToString()),
                    Country = rdr["Country"].ToString(),
                    Email = rdr["Email"].ToString(),

                    BirthDay = Convert.ToDateTime(rdr["BirthDay"].ToString()),
                    Phone = rdr["Phone"].ToString(),
                    Password = rdr["Password"].ToString(),
                };
            }
            con.Close();
            return aStudent;
        }
    }
}