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
using TecoBerBP.ControllerHelpers;

namespace TecoBerBP.Controllers
{
    [Authorize]
    public class BPUsersController : Controller
    {
        private TecoBerBPContext db = new TecoBerBPContext();

        // GET: BPUsers
        public ActionResult Index()
        {
            this.ViewBag.UserId = UserHelper.GetUserID(User.Identity.Name);

            BPUserViewModel BPuVM = new BPUserViewModel();
            
            return View(BPuVM.UserList()); // db.BPUsers.ToList()
        }

        // GET: BPUsers/Details/5
        public ActionResult Details(int? id)
        {
            this.ViewBag.UserId = UserHelper.GetUserID(User.Identity.Name);

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
            this.ViewBag.UserId = UserHelper.GetUserID(User.Identity.Name);

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
            this.ViewBag.UserId = UserHelper.GetUserID(User.Identity.Name);

            if (ModelState.IsValid)
            {
                if (bPUser.RoleId <= 0)
                    bPUser.RoleId = EnAuthenticationLevel.User; // 1

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

            this.ViewBag.UserId = UserHelper.GetUserID(User.Identity.Name);

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
            this.ViewBag.UserId = UserHelper.GetUserID(User.Identity.Name);

            if (ModelState.IsValid)
            {
                if (bPUser.RoleId <= 0)
                    bPUser.RoleId = EnAuthenticationLevel.User; // 1

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

            this.ViewBag.UserId = UserHelper.GetUserID(User.Identity.Name);

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
            this.ViewBag.UserId = UserHelper.GetUserID(User.Identity.Name);

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
