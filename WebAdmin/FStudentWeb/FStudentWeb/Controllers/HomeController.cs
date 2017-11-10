using FStudentWeb.DAO;
using FStudentWeb.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FStudentWeb.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        //10?name=Pragim
        //string s = Request.QueryString["name"];
        public ActionResult Index()
        {
            string admin = (string)Session["login_session"];
            if (admin == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult CheckLogin(string username, string password)
        {
            AdminDAO dao = new AdminDAO();
            var user = dao.CheckLoginAdmin(username, password);
            bool isValid = user == null ? false : true;
            if (isValid)
            {
                Session["login_session"] = user;
            }
            var obj = new
            {
                valid = isValid
            };
            return Json(obj);
        }

        public ActionResult ManageStudent()
        {

            string admin = (string)Session["login_session"];
            if (admin == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
            StudentDAO dao = new StudentDAO();
            List<Student> studentList = dao.GetStudentList();
            if (studentList != null && studentList.Count > 0)
            {
                ViewBag.StudentList = studentList;
            }
            
            return View();
        }

        public ActionResult StudentDetail(string studentID)
        {
            StudentDAO dao = new StudentDAO();
            Student student = dao.GetStudentByID(studentID);
            ViewBag.StudentInfor = student;

            return View();
        }
        
        public ActionResult StudentCourseDetail(string studentID)
        {
            SPDAO dao = new SPDAO();
            List<SemesterTranscriptModel> semesterTranscriptModelList = dao.GetAllSectionOfSpecificStudentService(studentID);
            ViewBag.StudentCourseInfor = semesterTranscriptModelList;
            ViewBag.StudentID = studentID;
            return View();
        }

        public ActionResult UpdateGrade(string studentID, string sectionID,string GPA)
        {
            bool isValid = false;
            double GPAnum = 0;
            bool validGrade  = double.TryParse(GPA,out GPAnum);
            if (validGrade)
            {
                StudentTranscriptDAO stDAO = new StudentTranscriptDAO();
                StudentTranscript st = stDAO.FindTranscript(studentID, sectionID);
                if (st != null)
                {
                    st.AverageGrade = GPAnum;
                    isValid = stDAO.UpdateTranscriptGrade(st.TranscriptID, st.AverageGrade);
                }
            }
            else
            {
                isValid = false;
            }
            
            var obj = new
            {
                valid = isValid
            };
            return Json(obj);
        }

        public ActionResult UpdateStudent(string studentID, string studentAddress,string studentPhone,string studentName)
        {
            bool isValid = false;
            StudentDAO studentDAO = new StudentDAO();
            Student student = studentDAO.GetStudentByID(studentID);
            if (student != null)
            {
                student.Address = studentAddress;
                student.Phone = studentPhone;
                student.StudentName = studentName;
                studentDAO.UpdateStudent1(student);
                isValid = true;
            }

            

            var obj = new
            {
                valid = isValid
            };
            return Json(obj);
        }

        public ActionResult ManageSection()
        {
            string admin = (string)Session["login_session"];
            if (admin == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
            SectionDAO dao = new SectionDAO();
            List<Section> sectionList = dao.GetSectionList();
            if (sectionList != null && sectionList.Count > 0)
            {
                ViewBag.sectionList = sectionList;
            }
            return View();
        }

        public ActionResult ViewSectionSchedule(string sectionID)
        {
            SectionScheduleDAO dao = new SectionScheduleDAO();
            List<SectionSchedule> sectionScheduleList = dao.GetAllSectionScheduleOfSection(sectionID);
            if (sectionScheduleList != null && sectionScheduleList.Count > 0)
            {
                ViewBag.sectionScheduleList = sectionScheduleList;
            }
            return View();
        }

        public ActionResult UpdateSectionSchedule(string sectionScheduleID,string room, string duration,string slot)
        {
            bool isValid = false;
            
            int durationNum = 0;
            int slotNum = 0;
            int sectionScheduleIDNum = 0;

            if (int.TryParse(duration, out durationNum) && int.TryParse(slot, out slotNum) 
                && int.TryParse(sectionScheduleID,out sectionScheduleIDNum))
            {
                SectionScheduleDAO dao = new SectionScheduleDAO();
                SectionSchedule sectionSchedule = dao.GetAllSectionScheduleByID(sectionScheduleIDNum);

                if (sectionSchedule != null)
                {
                    sectionSchedule.Room = room;
                    sectionSchedule.Duration = durationNum;
                    sectionSchedule.Slot = slotNum;
                    dao.UpdateSectionSchedule(sectionSchedule);
                    isValid = true;
                    string content = sectionSchedule.SectionID + " changed room " + room + " | slot: " + slot;
                    SendMessage(content);
                }
            }
            var obj = new
            {
                valid = isValid
            };
            return Json(obj);
        }

        private void SendMessage(string content)
        {
            string serverKey = "AIzaSyB049detSV0BLjmsDM32cma3h0fY2s1cSw";
            string mainToken = "cQdiow0g480:APA91bHz6PO0GzXvnI360GEr2m7nIAh1DWqP9spWRc_bb1WRhjMAeBtD8N1Wz5F_fQzCtex35XSllghnNggVFYgryf5ui8tvicdaw33FcocagaWVWXocuuRfg_ORpxuFkMCqJyGb9Rnz";
            try
            {
                var result = "-1";
                var webAddr = "https://fcm.googleapis.com/fcm/send";

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Headers.Add("Authorization:key=" + serverKey);
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"to\": \" " + mainToken + "\",\"data\": {\"message\": \"" + content + "\",}}";
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

                // return result;
            }
            catch (Exception ex)
            {
                //  Response.Write(ex.Message);
            }
        }

        public void CheckSession()
        {
            string admin = (string)Session["login_session"];
            if (admin == null)
                RedirectToAction("Login", "Home", new { area = "" });
        }

	}
}