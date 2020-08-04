using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Capstone_Application_Draft2.Models;
using Microsoft.AspNet.Identity;

namespace Capstone_Application_Draft2.Controllers
{
    public class UserinfoesController : Controller
    {
        private WeddingAppEntities db = new WeddingAppEntities();

        // GET: Userinfoes
        public ActionResult Index()
        {
            var userinfoes = db.Userinfoes.Include(u => u.Months_Until);
            return View(userinfoes.ToList());
        }

        // GET: Userinfoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userinfo userinfo = db.Userinfoes.Find(id);
            if (userinfo == null)
            {
                return HttpNotFound();
            }
            return View(userinfo);
        }

        // GET: Userinfoes/Create
        public ActionResult Create()
        {
            ViewBag.Months_Until_ID = new SelectList(db.Months_Until, "Months_Until_ID", "Months");
            return View();
        }

        // POST: Userinfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,First_name,Last_name,Email,Months_Until_ID")] Userinfo userinfo)
        {
            if (ModelState.IsValid)
            {
                db.Userinfoes.Add(userinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Months_Until_ID = new SelectList(db.Months_Until, "Months_Until_ID", "Months", userinfo.Months_Until_ID);
            return View(userinfo);
        }

        // GET: Userinfoes/Edit/5
        public ActionResult Edit()
        {
            var id = User.Identity.GetUserId();
            Userinfo userinfo = db.Userinfoes.Find(id);
            if (userinfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Months_Until_ID = new SelectList(db.Months_Until, "Months_Until_ID", "Months", userinfo.Months_Until_ID);
            return View(userinfo);
        }

        // POST: Userinfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,First_name,Last_name,Email,Months_Until_ID")] Userinfo userinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Months_Until_ID = new SelectList(db.Months_Until, "Months_Until_ID", "Months", userinfo.Months_Until_ID);
            return View(userinfo);
        }

        // GET: Userinfoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userinfo userinfo = db.Userinfoes.Find(id);
            if (userinfo == null)
            {
                return HttpNotFound();
            }
            return View(userinfo);
        }

        // POST: Userinfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Userinfo userinfo = db.Userinfoes.Find(id);
            db.Userinfoes.Remove(userinfo);
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
