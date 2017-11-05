
namespace FStudentWeb.DTO
{ 
    public class Student
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string Major { get; set; }
        public string Address { get; set; }
        public int Sex { get; set; }
        public System.DateTime BirthDay { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return string.Format("{0,-25} {1,-50}\n", StudentName, BirthDay);
        }
    }
}
