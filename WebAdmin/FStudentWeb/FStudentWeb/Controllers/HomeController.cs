using FStudentWeb.DAO;
using FStudentWeb.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void CheckSession()
        {
            string admin = (string)Session["login_session"];
            if (admin == null)
                RedirectToAction("Login", "Home", new { area = "" });
        }

	}
}