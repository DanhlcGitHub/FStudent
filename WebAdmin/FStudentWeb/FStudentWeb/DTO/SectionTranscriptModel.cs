using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FStudentWeb.DTO
{
    public class SectionTranscriptModel
    {
        public String sectionID { get; set; }
        public String status { get; set; }
        public int credit { get; set; }
        public double GPA { get; set; }

       
    }
}