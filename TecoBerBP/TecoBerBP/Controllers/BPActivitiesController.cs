using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TecoBerBP.DataModel;
using TecoBerBP.DataClasses;
using TecoBerBP.ControllerHelpers;


namespace TecoBerBP.Controllers
{
    [Authorize]
    public class BPActivitiesController : Controller
    {
        private TecoBerBPContext db = new TecoBerBPContext();

        // GET: Activities
        public ActionResult Index()
        {
            if (!UserHelper.IsUserAdmin(User.Identity.Name))
                RedirectToAction("Index", "Home");

            this.ViewBag.UserId = UserHelper.GetUserID(User.Identity.Name);

            return View(db.BPActivities.ToList());
        }

        // GET: Activities/Details/5
        public ActionResult Details(int? id)
        {
            if (!UserHelper.IsUserAdmin(User.Identity.Name))
                RedirectToAction("Index", "Home");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BPActivity activity = db.BPActivities.Find(id);

            if (activity == null)
            {
                return HttpNotFound();
            }

            this.ViewBag.UserId = UserHelper.GetUserID(User.Identity.Name);

            return View(activity);
        }

        // GET: Activities/Create
        public ActionResult Create()
        {
            if (!UserHelper.IsUserAdmin(User.Identity.Name))
                RedirectToAction("Index", "Home");

            this.ViewBag.UserId = UserHelper.GetUserID(User.Identity.Name);

            return View(new BPActivity());
        }

        // POST: Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActivityId, Name, Point, Duration, DurationUnit")] BPActivity activity)
        {
            if (!UserHelper.IsUserAdmin(User.Identity.Name))
                RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                db.BPActivities.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            this.ViewBag.UserId = UserHelper.GetUserID(User.Identity.Name);

            return View(activity);
        }

        // GET: Activities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!UserHelper.IsUserAdmin(User.Identity.Name))
                RedirectToAction("Index", "Home");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BPActivity activity = db.BPActivities.Find(id);

            if (activity == null)
            {
                return HttpNotFound();
            }

            this.ViewBag.UserId = UserHelper.GetUserID(User.Identity.Name);

            return View(activity);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActivityId, Name, Point, Duration, DurationUnit")] BPActivity activity)
        {
            if (!UserHelper.IsUserAdmin(User.Identity.Name))
                RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            this.ViewBag.UserId = UserHelper.GetUserID(User.Identity.Name);

            return View(activity);
        }

        // GET: Activities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!UserHelper.IsUserAdmin(User.Identity.Name))
                RedirectToAction("Index", "Home");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BPActivity activity = db.BPActivities.Find(id);

            if (activity == null)
            {
                return HttpNotFound();
            }

            this.ViewBag.UserId = UserHelper.GetUserID(User.Identity.Name);

            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!UserHelper.IsUserAdmin(User.Identity.Name))
                RedirectToAction("Index", "Home");

            BPActivity activity = db.BPActivities.Find(id);
            db.BPActivities.Remove(activity);
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
