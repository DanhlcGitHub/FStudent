using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FStudentWeb.DTO
{
    public class SemesterTranscriptModel
    {
        public int semesterID { get; set; }
        public String semesterName { get; set; }
        public int credit { get; set; }
        public double GPA { get; set; }
        public List<SectionTranscriptModel> sectionTranscriptModel { get; set; }

        public void CalculateGPAAndCredit()
        {
            int totalCredit = 0;
            double totalGPA = 0;
            foreach (var item in sectionTranscriptModel)
            {
                totalCredit += item.credit;
                totalGPA += item.GPA;
            }
            this.GPA = totalGPA / sectionTranscriptModel.Count;
            this.credit = totalCredit;
        }
    }
}