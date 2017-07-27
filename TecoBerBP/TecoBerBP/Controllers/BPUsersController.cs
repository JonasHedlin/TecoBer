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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BPUser bPUser = db.BPUsers.Find(id);

            if (bPUser == null)
            {
                return HttpNotFound();
            }

            this.ViewBag.UserId = UserHelper.GetUserID(User.Identity.Name);

            return View(bPUser);
        }

        // GET: BPUsers/Create
        public ActionResult Create()
        {
            if (!UserHelper.IsUserAdmin(User.Identity.Name))
                RedirectToAction("Index", "Home");

            this.ViewBag.UserId = UserHelper.GetUserID(User.Identity.Name);

            return View();
        }

        // POST: BPUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId, Name, SurName, CLSID, Gender, Email, AltEmail, Titel, AreaOfExpertise, Cell, " +
            "Company, CompanyNo, CompanyAddress, CompanyZip, CompanyCity, OfficeLocation, CompanyLead, DateOfBirth, JoinedDate, " +
            "QuitDate, Comment, Status, RoleID")] BPUser bPUser)
        {
            if (!UserHelper.IsUserAdmin(User.Identity.Name))
                RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                if (bPUser.RoleId <= 0)
                    bPUser.RoleId = EnAuthenticationLevel.User; // 1

                if (string.IsNullOrEmpty(bPUser.CLSID) == true)
                    bPUser.CLSID = Guid.NewGuid().ToString();

                db.BPUsers.Add(bPUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            this.ViewBag.UserId = UserHelper.GetUserID(User.Identity.Name);

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

            if (UserHelper.IsUserAdmin(User.Identity.Name) || id == UserHelper.GetUserID(User.Identity.Name))
            {                
                if (bPUser == null)
                {
                    return HttpNotFound();
                }

                this.ViewBag.UserId = UserHelper.GetUserID(User.Identity.Name);
                
            }
            else RedirectToAction("Index", "Home");

            return View(bPUser);

        }

        // POST: BPUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId, Name, SurName, CLSID, Gender, Email, AltEmail, Titel, AreaOfExpertise, Cell, " +
            "Company, CompanyNo, CompanyAddress, CompanyZip, CompanyCity, OfficeLocation, CompanyLead, DateOfBirth, JoinedDate, " +
            "QuitDate, Comment, Status, RoleID")] BPUser bPUser)
        {
            if (UserHelper.IsUserAdmin(User.Identity.Name) || bPUser.UserId == UserHelper.GetUserID(User.Identity.Name))
            {
                
                if (ModelState.IsValid)
                {
                    if (bPUser.RoleId <= 0)
                        bPUser.RoleId = EnAuthenticationLevel.User; // 1

                    //if (string.IsNullOrEmpty(bPUser.CLSID) == true) // TODO! Remove this code!
                    //    bPUser.CLSID = Guid.NewGuid().ToString();

                    db.Entry(bPUser).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                this.ViewBag.UserId = UserHelper.GetUserID(User.Identity.Name);
                
            }
            else RedirectToAction("Index", "Home");

            return View(bPUser);
        }

        // GET: BPUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!UserHelper.IsUserAdmin(User.Identity.Name))
                RedirectToAction("Index", "Home");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            BPUser bPUser = db.BPUsers.Find(id);

            if (bPUser == null)
            {
                return HttpNotFound();
            }

            this.ViewBag.UserId = UserHelper.GetUserID(User.Identity.Name);

            return View(bPUser);
        }

        // POST: BPUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!UserHelper.IsUserAdmin(User.Identity.Name))
                RedirectToAction("Index", "Home");

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
