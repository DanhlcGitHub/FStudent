using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Views/Home/Login.cshtml");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CheckLogin(string username, string password)
        {
            var user = "123";
            bool isValid = user.Length == 0 ? false : true;
            if (isValid)
            {
                Session["login_session"] = user[0];
            }
            var obj = new
            {
                valid = isValid
            };
            return Json(obj);
        }
    }
}