using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TecoBerBP.DataClasses;
using TecoBerBP.DataModel;

namespace TecoBerBP.Controllers
{
    public class BPUserActivitiesController : Controller
    {
        private TecoBerBPContext db = new TecoBerBPContext();

        // GET: BPUserActivities
        public ActionResult Index()
        {


            return View(db.BPUserActivities.ToList());
        }

        // GET: BPUserActivities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BPUserActivity bPUserActivity = db.BPUserActivities.Find(id);

            if (bPUserActivity == null)
            {
                return HttpNotFound();
            }
            return View(bPUserActivity);
        }

        // GET: BPUserActivities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BPUserActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserActivityId, Name, DateForActivity, Description, CompanyLeadUserId, UserId, ActivityId")] BPUserActivity bPUserActivity)
        {
            if (ModelState.IsValid)
            {
                db.BPUserActivities.Add(bPUserActivity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bPUserActivity);
        }

        // GET: BPUserActivities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BPUserActivity bPUserActivity = db.BPUserActivities.Find(id);

            if (bPUserActivity == null)
            {
                return HttpNotFound();
            }
            return View(bPUserActivity);
        }

        // POST: BPUserActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserActivityId, Name, DateForActivity, Description, CompanyLeadUserId, UserId, ActivityId")] BPUserActivity bPUserActivity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bPUserActivity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bPUserActivity);
        }

        // GET: BPUserActivities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BPUserActivity bPUserActivity = db.BPUserActivities.Find(id);

            if (bPUserActivity == null)
            {
                return HttpNotFound();
            }
            return View(bPUserActivity);
        }

        // POST: BPUserActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BPUserActivity bPUserActivity = db.BPUserActivities.Find(id);
            db.BPUserActivities.Remove(bPUserActivity);
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
