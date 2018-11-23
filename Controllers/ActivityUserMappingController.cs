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
    public class ActivityUserMappingController : Controller
    {
        private AfterWorkEntity db = new AfterWorkEntity();

        public ActionResult ActivityUserMappingList()
        {
            var activityUserMappings = db.ActivityUserMappings.Include(a => a.Activity).Include(a => a.User);
            return View(activityUserMappings.ToList());
        }

        public ActionResult ActivityUserMappingDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityUserMapping activityUserMapping = db.ActivityUserMappings.Find(id);
            if (activityUserMapping == null)
            {
                return HttpNotFound();
            }
            return View(activityUserMapping);
        }

        public ActionResult ActivityUserMappingCreate()
        {
            ViewBag.activity_id = new SelectList(db.Activities, "activity_id", "activity_name");
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActivityUserMappingCreate([Bind(Include = "Id,user_id,activity_id,time_limit,from_time,to_time")] ActivityUserMapping activityUserMapping)
        {
            if (ModelState.IsValid)
            {
                db.ActivityUserMappings.Add(activityUserMapping);
                db.SaveChanges();
                return RedirectToAction("ActivityUserMappingList");
            }

            ViewBag.activity_id = new SelectList(db.Activities, "activity_id", "activity_name", activityUserMapping.activity_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_name", activityUserMapping.user_id);
            return View(activityUserMapping);
        }

        public ActionResult ActivityUserMappingEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityUserMapping activityUserMapping = db.ActivityUserMappings.Find(id);
            if (activityUserMapping == null)
            {
                return HttpNotFound();
            }
            ViewBag.activity_id = new SelectList(db.Activities, "activity_id", "activity_name", activityUserMapping.activity_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_name", activityUserMapping.user_id);
            return View(activityUserMapping);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActivityUserMappingEdit([Bind(Include = "Id,user_id,activity_id,time_limit,from_time,to_time")] ActivityUserMapping activityUserMapping)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activityUserMapping).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ActivityUserMappingList");
            }
            ViewBag.activity_id = new SelectList(db.Activities, "activity_id", "activity_name", activityUserMapping.activity_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_name", activityUserMapping.user_id);
            return View(activityUserMapping);
        }

        public ActionResult ActivityUserMappingDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityUserMapping activityUserMapping = db.ActivityUserMappings.Find(id);
            if (activityUserMapping == null)
            {
                return HttpNotFound();
            }
            return View(activityUserMapping);
        }

        [HttpPost, ActionName("ActivityUserMappingDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActivityUserMapping activityUserMapping = db.ActivityUserMappings.Find(id);
            db.ActivityUserMappings.Remove(activityUserMapping);
            db.SaveChanges();
            return RedirectToAction("ActivityUserMappingList");
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
