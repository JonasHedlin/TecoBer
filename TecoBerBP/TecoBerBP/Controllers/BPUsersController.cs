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
using TecoBerBP.ViewModels;
using TecoBerBP.DataClasses.Enum;

namespace TecoBerBP.Controllers
{
    [Authorize]
    public class BPUsersController : Controller
    {
        private TecoBerBPContext db = new TecoBerBPContext();

        // GET: BPUsers
        public ActionResult Index()
        {
            BPUserViewModel BPuVM = new BPUserViewModel();
            
            return View(BPuVM.UserList()); // db.BPUsers.ToList()
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
        public ActionResult Create([Bind(Include = "UserId, Name, SurName, Gender, Email, AltEmail, Titel, AreaOfExpertise, Cell, " +
            "Company, CompanyNo, CompanyAddress, CompanyZip, CompanyCity, OfficeLocation, CompanyLead, DateOfBirth, JoinedDate, " +
            "QuiteDate, Comment, Status, RoleID")] BPUser bPUser)
        {
            if (ModelState.IsValid)
            {
                if (bPUser.RoleId <= 0)
                    bPUser.RoleId = AuthenticationLevel.User; // 1

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
        public ActionResult Edit([Bind(Include = "UserId, Name, SurName, Gender, Email, AltEmail, Titel, AreaOfExpertise, Cell, " +
            "Company, CompanyNo, CompanyAddress, CompanyZip, CompanyCity, OfficeLocation, CompanyLead, DateOfBirth, JoinedDate, " +
            "QuiteDate, Comment, Status, RoleID")] BPUser bPUser)
        {
            if (ModelState.IsValid)
            {
                if (bPUser.RoleId <= 0)
                    bPUser.RoleId = AuthenticationLevel.User; // 1

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
