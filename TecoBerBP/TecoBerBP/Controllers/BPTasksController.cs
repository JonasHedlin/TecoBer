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
    [Authorize]
    public class BPTasksController : Controller
    {
        private TecoBerBPContext db = new TecoBerBPContext();

        // GET: BPTasks
        public ActionResult Index()
        {
            return View(db.BPTasks.ToList());
        }

        // GET: BPTasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BPTask bPTask = db.BPTasks.Find(id);
            if (bPTask == null)
            {
                return HttpNotFound();
            }
            return View(bPTask);
        }

        // GET: BPTasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BPTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaskId,Name,Comment,Point,Date")] BPTask bPTask)
        {
            if (ModelState.IsValid)
            {
                db.BPTasks.Add(bPTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bPTask);
        }

        // GET: BPTasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BPTask bPTask = db.BPTasks.Find(id);
            if (bPTask == null)
            {
                return HttpNotFound();
            }
            return View(bPTask);
        }

        // POST: BPTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaskId,Name,Comment,Point,Date")] BPTask bPTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bPTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bPTask);
        }

        // GET: BPTasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BPTask bPTask = db.BPTasks.Find(id);
            if (bPTask == null)
            {
                return HttpNotFound();
            }
            return View(bPTask);
        }

        // POST: BPTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BPTask bPTask = db.BPTasks.Find(id);
            db.BPTasks.Remove(bPTask);
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
