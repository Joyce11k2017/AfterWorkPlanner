using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AfterWorkPlanner.Models;

namespace AfterWorkPlanner.Controllers
{
    public class RoleController : Controller
    {
        private AfterWorkEntity db = new AfterWorkEntity();

        public ActionResult RoleList()
        {
            var roles = db.Roles.Include(r => r.User);
            return View(roles.ToList());
        }

        public ActionResult RoleDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        public ActionResult RoleCreate()
        {
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleCreate([Bind(Include = "role_id,role_name,user_id,Edit,Create,Delete,View,created_dt_tm,modified_dt_tm")] Role role)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(role);
                db.SaveChanges();
                return RedirectToAction("RoleDetails");
            }

            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_name", role.user_id);
            return View(role);
        }

        public ActionResult RoleEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_name", role.user_id);
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleEdit([Bind(Include = "role_id,role_name,user_id,Edit,Create,Delete,View,created_dt_tm,modified_dt_tm")] Role role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("RoleList");
            }
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_name", role.user_id);
            return View(role);
        }

        public ActionResult RoleDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        [HttpPost, ActionName("RoleDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Role role = db.Roles.Find(id);
            db.Roles.Remove(role);
            db.SaveChanges();
            return RedirectToAction("RoleList");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
