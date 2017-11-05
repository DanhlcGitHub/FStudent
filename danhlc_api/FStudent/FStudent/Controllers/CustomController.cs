using FStudent.DAO;
using FStudent.DTO;
using FStudent.DTOMY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace FStudent.Controllers
{
    public class CustomController : ApiController
    {
        [Route("api/custom/login/")]
        public IHttpActionResult PostStudentLogin()
        {

            var httpRequest = HttpContext.Current.Request;
            string studentID = httpRequest.Form.GetValues("StudentID")[0];
            string password = httpRequest.Form.GetValues("Password")[0];

            StudentDAO dao = new StudentDAO();
            int result = dao.CheckLogin(studentID,password);
            return Ok(result);
        }

        [Route("api/custom/PostGetStudentByID/")]
        public IHttpActionResult PostGetStudentByID()
        {

            var httpRequest = HttpContext.Current.Request;
            string studentID = httpRequest.Form.GetValues("StudentID")[0];

            StudentDAO dao = new StudentDAO();
            Student student = dao.GetStudentByID(studentID);
            return Ok(student);
        }

        [Route("api/custom/PostGetCurrentSemester/")]
        public IHttpActionResult PostGetCurrentSemester()
        {

            var httpRequest = HttpContext.Current.Request;
            string currentDate = httpRequest.Form.GetValues("currentDate")[0];

            CustomDAO dao = new CustomDAO();
            int semesterID = dao.GetCurrentSemesterID(currentDate);
            return Ok(semesterID);
        }

        [Route("api/custom/PostGetAllWeekInSemester/")]
        public IHttpActionResult PostGetAllWeekInSemester()
        {

            var httpRequest = HttpContext.Current.Request;
            String semesterIDStr = httpRequest.Form.GetValues("semesterID")[0];
            int semesterID = Convert.ToInt32(semesterIDStr);

            CustomDAO dao = new CustomDAO();
            List<String> weekList = dao.GetAllWeekInSemester(semesterID);
            return Ok(weekList);
        }

        [Route("api/custom/GetListSectionScheduleInWeek/")]
        public IHttpActionResult PostGetListSectionScheduleInWeek()
        {

            var httpRequest = HttpContext.Current.Request;
            String datePeriod = httpRequest.Form.GetValues("datePeriod")[0];
            String semesterIDStr = httpRequest.Form.GetValues("semesterID")[0];
            String studentID = httpRequest.Form.GetValues("studentID")[0];
            int semesterID = Convert.ToInt32(semesterIDStr);

            CustomDAO dao = new CustomDAO();
            List<SectionSchedule> sectionScheduleList = dao.GetListSectionScheduleInWeekByStudentBySemester(datePeriod,semesterID,studentID);
            return Ok(sectionScheduleList);
        }

        [Route("api/custom/GetAllSectionOfSpecificStudentService/")]
        public IHttpActionResult PostGetAllSectionOfSpecificStudentService()
        {

            var httpRequest = HttpContext.Current.Request;
            String studentID = httpRequest.Form.GetValues("studentID")[0];

            CustomDAO dao = new CustomDAO();
            List<SemesterTranscriptModel> semesterTranscriptModelList = dao.GetAllSectionOfSpecificStudentService(studentID);
            return Ok(semesterTranscriptModelList);
        }
    }
}
