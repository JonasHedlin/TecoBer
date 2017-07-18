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


namespace TecoBerBP.Controllers
{
    [Authorize]
    public class BPUsersController : Controller
    {
        private TecoBerBPContext db = new TecoBerBPContext();

        // GET: BPUsers
        public ActionResult Index()
        {
            return View(db.BPUsers.ToList());
        }

        // GET: BPUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BPUser bPUser = db.BPUsers.Find(id);
            if (bPUser == null)
            {
                return HttpNotFound();
            }
            return View(bPUser);
        }

        // GET: BPUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BPUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Name, Email, AltEmail, Titel, AreaOfExpertise, Cell, Company, CompanyNo, CompanyAddress, CompanyZip, CompanyCity, OfficeLocation, CompanyLead")] BPUser bPUser)
        {
            if (ModelState.IsValid)
            {
                db.BPUsers.Add(bPUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bPUser);
        }

        // GET: BPUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BPUser bPUser = db.BPUsers.Find(id);
            if (bPUser == null)
            {
                return HttpNotFound();
            }
            return View(bPUser);
        }

        // POST: BPUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, Email, AltEmail, Titel, AreaOfExpertise, Cell, Company, CompanyNo, CompanyAddress, CompanyZip, CompanyCity, OfficeLocation, CompanyLead")] BPUser bPUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bPUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bPUser);
        }

        // GET: BPUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BPUser bPUser = db.BPUsers.Find(id);
            if (bPUser == null)
            {
                return HttpNotFound();
            }
            return View(bPUser);
        }

        // POST: BPUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BPUser bPUser = db.BPUsers.Find(id);
            db.BPUsers.Remove(bPUser);
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
