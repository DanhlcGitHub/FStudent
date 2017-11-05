using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPTAdmin.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
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