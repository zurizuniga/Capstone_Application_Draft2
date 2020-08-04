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
    [Authorize]
    public class Custom_User_ListController : Controller
    {
        private WeddingAppEntities db = new WeddingAppEntities();

        // GET: Custom_User_List
        public ActionResult Index()
        {
            var userID = User.Identity.GetUserId();
            var userInfo = db.Userinfoes.Find(userID);

            var custom_User_List = userInfo.Custom_User_List;
            return View(custom_User_List.ToList());
        }

        // GET: Custom_User_List/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Custom_User_List custom_User_List = db.Custom_User_List.Find(id);
            if (custom_User_List == null)
            {
                return HttpNotFound();
            }
            return View(custom_User_List);
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
            return PartialView(stuffToDo);
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

            return PartialView(stuff_To_Do);
        }

        // GET: Custom_User_List/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Custom_User_List custom_User_List = db.Custom_User_List.Find(id);
            if (custom_User_List == null || custom_User_List.User_ID != User.Identity.GetUserId()) 
            {
                return HttpNotFound();
            }
            ViewBag.Status_ID = new SelectList(db.Progress_Status, "Progress_Status_ID", "Status_Name", custom_User_List.Status_ID);
            return View(custom_User_List);
        }

        // POST: Custom_User_List/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Custom_List_ID,User_ID,Stuff_to_do_ID,Status_ID")] Custom_User_List custom_User_List)
        {
            
            if (ModelState.IsValid)
            {
                if (custom_User_List.User_ID != User.Identity.GetUserId())
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                db.Entry(custom_User_List).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Status_ID = new SelectList(db.Progress_Status, "Progress_Status_ID", "Status_Name", custom_User_List.Status_ID);
            custom_User_List.Stuff_To_Do = db.Stuff_To_Do.Find(custom_User_List.Stuff_to_do_ID);
            return View(custom_User_List);
        }

        // GET: Custom_User_List/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Custom_User_List custom_User_List = db.Custom_User_List.Find(id);
            if (custom_User_List == null)
            {
                return HttpNotFound();
            }
            return View(custom_User_List);
        }

        // POST: Custom_User_List/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Custom_User_List custom_User_List = db.Custom_User_List.Find(id);
            db.Custom_User_List.Remove(custom_User_List);
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
