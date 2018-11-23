using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AfterWorkController : Controller
    {
        private AftWrkDBContext db = new AftWrkDBContext();

        // GET: AfterWorks
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: AfterWorks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AfterWork afterWork = db.Users.Find(id);
            if (afterWork == null)
            {
                return HttpNotFound();
            }
            return View(afterWork);
        }

        // GET: AfterWorks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AfterWorks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_name,user_pwd")] AfterWork afterWork)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(afterWork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(afterWork);
        }

        // GET: AfterWorks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AfterWork afterWork = db.Users.Find(id);
            if (afterWork == null)
            {
                return HttpNotFound();
            }
            return View(afterWork);
        }

        // POST: AfterWorks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_name,user_pwd")] AfterWork afterWork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(afterWork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(afterWork);
        }

        // GET: AfterWorks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AfterWork afterWork = db.Users.Find(id);
            if (afterWork == null)
            {
                return HttpNotFound();
            }
            return View(afterWork);
        }

        // POST: AfterWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AfterWork afterWork = db.Users.Find(id);
            db.Users.Remove(afterWork);
            db.SaveChanges();
            return RedirectToAction("Index");
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
