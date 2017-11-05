using FAdmin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAdmin.DAO
{
    class CustomService
    {
        public List<SectionSchedule> GetListSectionScheduleInWeekByStudentBySemester(string datePeriod,int semesterID,string studentID)
        {
            SPDAO dao = new SPDAO();
            List<SectionSchedule> finalList = new List<SectionSchedule>();
            List<StudentTranscript> StudentTranscriptList = dao.GetStudentTranscriptByStudentID(studentID);

            for (int i = 0; i < StudentTranscriptList.Count; i++)
            {
                StudentTranscript st = StudentTranscriptList[i];
                Section sec = dao.GetSectionByID(st.SectionID);
                if (sec.SemesterBelong == semesterID)
                {
                    List<SectionSchedule> subList = dao.GetListSectionScheduleInPeriod(datePeriod, st.SectionID);
                    foreach (var item in subList)
                    {
                        finalList.Add(item);
                    }
                }
            }
            return finalList;
        }
    }
}
