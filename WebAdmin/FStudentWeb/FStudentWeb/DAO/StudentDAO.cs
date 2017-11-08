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
    class StudentDAO
    {
        public List<Student> GetStudentList()
        {
            List<Student> StudentList = new List<Student>();
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Select * from Student", con);

            con.Open();
            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Student c = new Student()
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
                StudentList.Add(c);
            }
            con.Close();
            return StudentList;
        }

        public bool IsStudentExist(string studentID)
        {
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Select * from Student where StudentID = (@ID)", con);

            SqlParameter ParameterStudentID = new SqlParameter();
            ParameterStudentID.ParameterName = "@ID";
            ParameterStudentID.Value = studentID;

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

        public bool DeleteStudent(string studentID)
        {
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Delete from Student where StudentID = (@ID)", con);

            SqlParameter ParameterStudentID = new SqlParameter();
            ParameterStudentID.ParameterName = "@ID";
            ParameterStudentID.Value = studentID;

            cmd.Parameters.Add(ParameterStudentID);

            con.Open();
            int row = -1;
            row = cmd.ExecuteNonQuery();
            con.Close();
            return row < 0 ? false : true;
        }

        public bool InsertStudent(string StudentID, string StudentName, string Major, string Address, int Sex, string Country,
            string Email, DateTime BirthDay, string Phone, string Password)
        {
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("INSERT INTO Student (StudentID,StudentName,Major,Address,Sex,Country,Email,BirthDay,Phone,Password) "
            + "VALUES (@StudentID,@StudentName,@Major,@Address,@Sex,@Country,@Email,@BirthDay,@Phone,@Password)", con);

            SqlParameter ParameterStudentID = new SqlParameter();
            ParameterStudentID.ParameterName = "@StudentID";
            ParameterStudentID.Value = StudentID;

            SqlParameter ParameterStudentName = new SqlParameter();
            ParameterStudentName.ParameterName = "@StudentName";
            ParameterStudentName.Value = StudentName;

            SqlParameter ParameterMajor = new SqlParameter();
            ParameterMajor.ParameterName = "@Major";
            ParameterMajor.Value = Major;

            SqlParameter ParameterAddress = new SqlParameter();
            ParameterAddress.ParameterName = "@Address";
            ParameterAddress.Value = Address;

            SqlParameter ParameterSex = new SqlParameter();
            ParameterSex.ParameterName = "@Sex";
            ParameterSex.Value = Sex;

            SqlParameter ParameterCountry = new SqlParameter();
            ParameterCountry.ParameterName = "@Country";
            ParameterCountry.Value = Country;

            SqlParameter ParameterEmail = new SqlParameter();
            ParameterEmail.ParameterName = "@Email";
            ParameterEmail.Value = Email;

            SqlParameter ParameterBirthDay = new SqlParameter();
            ParameterBirthDay.ParameterName = "@BirthDay";
            ParameterBirthDay.Value = BirthDay;

            SqlParameter ParameterPhone = new SqlParameter();
            ParameterPhone.ParameterName = "@Phone";
            ParameterPhone.Value = Phone;

            SqlParameter ParameterPassword = new SqlParameter();
            ParameterPassword.ParameterName = "@Password";
            ParameterPassword.Value = Password;

            cmd.Parameters.Add(ParameterStudentID);
            cmd.Parameters.Add(ParameterStudentName);
            cmd.Parameters.Add(ParameterAddress);
            cmd.Parameters.Add(ParameterSex);
            cmd.Parameters.Add(ParameterMajor);
            cmd.Parameters.Add(ParameterCountry);
            cmd.Parameters.Add(ParameterEmail);
            cmd.Parameters.Add(ParameterBirthDay);
            cmd.Parameters.Add(ParameterPhone);
            cmd.Parameters.Add(ParameterPassword);

            con.Open();
            int row = -1;
            row = cmd.ExecuteNonQuery();
            con.Close();
            return row < 0 ? false : true;
        }

        public bool UpdateStudent(string StudentID, string StudentName, string Major, string Address, int Sex, string Country,
            string Email, DateTime BirthDay, string Phone, string Password)
        {
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Update Student set StudentName = (@StudentName) , "
                + "Major = (@Major), Address = (@Address), Sex = (@Sex), Country = (@Country), Email = (@Email), " +
                " BirthDay = (@BirthDay), Phone = (@Phone),Password = (@Password) where StudentID = (@StudentID)", con);

            cmd.Parameters.AddWithValue("@StudentID", StudentID);
            cmd.Parameters.AddWithValue("@StudentName", StudentName);
            cmd.Parameters.AddWithValue("@Major", Major);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Sex", Sex);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@BirthDay", BirthDay);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Password", Password);

            con.Open();
            int row = -1;
            row = cmd.ExecuteNonQuery();
            con.Close();
            return row < 0 ? false : true;
        }

        public bool UpdateStudent1(Student student)
        {
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Update Student set StudentName = (@StudentName) , "
                + "Major = (@Major), Address = (@Address), Sex = (@Sex), Country = (@Country), Email = (@Email), " +
                " BirthDay = (@BirthDay), Phone = (@Phone),Password = (@Password) where StudentID = (@StudentID)", con);

            cmd.Parameters.AddWithValue("@StudentID", student.StudentID);
            cmd.Parameters.AddWithValue("@StudentName", student.StudentName);
            cmd.Parameters.AddWithValue("@Major", student.Major);
            cmd.Parameters.AddWithValue("@Address", student.Address);
            cmd.Parameters.AddWithValue("@Sex", student.Sex);
            cmd.Parameters.AddWithValue("@Country", student.Country);
            cmd.Parameters.AddWithValue("@Email", student.Email);
            cmd.Parameters.AddWithValue("@BirthDay", student.BirthDay);
            cmd.Parameters.AddWithValue("@Phone", student.Phone);
            cmd.Parameters.AddWithValue("@Password", student.Password);

            con.Open();
            int row = -1;
            row = cmd.ExecuteNonQuery();
            con.Close();
            return row < 0 ? false : true;
        }

        public Student GetStudentByID(String studentID)
        {
            Student student = null;
            SqlConnection con = BaseDAO.GetConnection();
            SqlCommand cmd = new SqlCommand("Select * from Student where StudentID = (@ID)", con);
            cmd.Parameters.AddWithValue("@ID", studentID);

            con.Open();
            var rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                Student c = new Student()
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
                student = c;
            }
            con.Close();
            return student ;
        }
    }
}
