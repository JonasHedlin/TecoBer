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
    public class BPRolesController : Controller
    {
        private TecoBerBPContext db = new TecoBerBPContext();

        // GET: BPRoles
        public ActionResult Index()
        {
            return View(db.BPRoles.ToList());
        }

        // GET: BPRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BPRole bPRole = db.BPRoles.Find(id);
            if (bPRole == null)
            {
                return HttpNotFound();
            }
            return View(bPRole);
        }

        // GET: BPRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BPRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoleId, Name, AuthenticationLevel")] BPRole bPRole)
        {
            if (ModelState.IsValid)
            {
                db.BPRoles.Add(bPRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bPRole);
        }

        // GET: BPRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BPRole bPRole = db.BPRoles.Find(id);
            if (bPRole == null)
            {
                return HttpNotFound();
            }
            return View(bPRole);
        }

        // POST: BPRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoleId, Name, AuthenticationLevel")] BPRole bPRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bPRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bPRole);
        }

        // GET: BPRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BPRole bPRole = db.BPRoles.Find(id);
            if (bPRole == null)
            {
                return HttpNotFound();
            }
            return View(bPRole);
        }

        // POST: BPRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BPRole bPRole = db.BPRoles.Find(id);
            db.BPRoles.Remove(bPRole);
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
