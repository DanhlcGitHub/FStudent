//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APIDEMO.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public Student()
        {
            this.StudentTranscripts = new HashSet<StudentTranscript>();
        }
    
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
    
        public virtual ICollection<StudentTranscript> StudentTranscripts { get; set; }
    }
}