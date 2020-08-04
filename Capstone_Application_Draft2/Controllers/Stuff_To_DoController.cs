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
    public class Stuff_To_DoController : Controller
    {
        private WeddingAppEntities db = new WeddingAppEntities();

        // GET: Stuff_To_Do
        public ActionResult Index()
        {
            var stuff_To_Do = db.Stuff_To_Do.Include(s => s.Months_Until).Include(s => s.Userinfo);
            return View(stuff_To_Do.ToList());
        }

        // GET: Stuff_To_Do/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stuff_To_Do stuff_To_Do = db.Stuff_To_Do.Find(id);
            if (stuff_To_Do == null)
            {
                return HttpNotFound();
            }
            return View(stuff_To_Do);
        }

        // GET: Stuff_To_Do/Create
        [Authorize]
        public ActionResult Create()
        {
            var User_ID = User.Identity.GetUserId();
            var userProfile = db.Userinfoes.Find(User_ID);
            var stuffToDo = new Stuff_To_Do
            {
                User_ID = User_ID,
                Months_Until_ID = userProfile.Months_Until_ID,

            };
            return View(stuffToDo);
        }

        // POST: Stuff_To_Do/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Stuff_To_Do_ID,Months_Until_ID,Todo_Items,Description,User_ID")] Stuff_To_Do stuff_To_Do)
        {
            if (ModelState.IsValid)
            {
                var User_ID = User.Identity.GetUserId();
                var userProfile = db.Userinfoes.Find(User_ID);
                var customUserList = new Custom_User_List
                {
                    Status_ID = 1,
                    Stuff_To_Do = stuff_To_Do,

                };
                stuff_To_Do.User_ID = User_ID;
                userProfile.Custom_User_List.Add(customUserList);
                db.Entry(userProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Custom_User_List");
            }

            return View(stuff_To_Do);
        }

        // GET: Stuff_To_Do/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stuff_To_Do stuff_To_Do = db.Stuff_To_Do.Find(id);
            if (stuff_To_Do == null)
            {
                return HttpNotFound();
            }
            ViewBag.Months_Until_ID = new SelectList(db.Months_Until, "Months_Until_ID", "Months", stuff_To_Do.Months_Until_ID);
            ViewBag.User_ID = new SelectList(db.Userinfoes, "UserID", "First_name", stuff_To_Do.User_ID);
            return View(stuff_To_Do);
        }

        // POST: Stuff_To_Do/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Stuff_To_Do_ID,Months_Until_ID,Todo_Items,Description,User_ID")] Stuff_To_Do stuff_To_Do)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stuff_To_Do).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Months_Until_ID = new SelectList(db.Months_Until, "Months_Until_ID", "Months", stuff_To_Do.Months_Until_ID);
            ViewBag.User_ID = new SelectList(db.Userinfoes, "UserID", "First_name", stuff_To_Do.User_ID);
            return View(stuff_To_Do);
        }

        // GET: Stuff_To_Do/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stuff_To_Do stuff_To_Do = db.Stuff_To_Do.Find(id);
            if (stuff_To_Do == null)
            {
                return HttpNotFound();
            }
            return View(stuff_To_Do);
        }

        // POST: Stuff_To_Do/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stuff_To_Do stuff_To_Do = db.Stuff_To_Do.Find(id);
            db.Stuff_To_Do.Remove(stuff_To_Do);
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
