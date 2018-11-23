using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AfterWorkPlanner.Models;

namespace AfterWorkPlanner.Controllers
{
    public class LoginController : Controller
    {
        public string datee;
        public ActionResult Login()
        {
            Session["RoleName"] = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User objUser)
        {
            if (ModelState.IsValid)
            {
                using (AfterWorkEntity db = new AfterWorkEntity())
                {
                    var obj = db.Users.Where(a => a.user_name.Equals(objUser.user_name) && a.user_pwd.Equals(objUser.user_pwd)).FirstOrDefault();
                    if (obj != null && obj.Roles.Count > 0)
                    {
                        Session["RoleName"] = obj.Roles.FirstOrDefault().role_name;
                        return RedirectToAction("../User/UserList");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}