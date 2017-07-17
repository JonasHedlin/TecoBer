using System;
using System.Collections.Generic;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TecoBerBP.DataModel;
//using TecoBerBP.ControllersHelper;
using TecoBerBP.ViewModels;
using TecoBerBP.DataClasses;

namespace TecoBerBP.Controllers
{
    [Authorize]
    public class BPRolesController : Controller
    {
        private TecoBerBPContext _context = new TecoBerBPContext();

        
        public ActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;

                //if (!UserHelper.IsAdminUser(user)) // Only administrator have access to this page.
                //{
                //    return RedirectToAction("Index", "Home");
                //}
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            var Roles = _context.BPRoles.ToList();
            return View(Roles);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("CreateRole");
        }

        [HttpPost]
        public ActionResult Create(BPRoleViewModel model)
        {
            // Add new role here!
            if (ModelState.IsValid)
            {
                //ApplicationDbContext context = new ApplicationDbContext();
                //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));

                var role = new BPRole();  // Microsoft.AspNet.Identity.EntityFramework.IdentityRole(); // object with id created.
                role.Name = model.Name;
                //roleManager.Create(role);

                ModelState.Clear();

                ViewBag.UserMessage = "New role created!";
            }

            return View("CreateRole");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Name, AuthenticationLevel")] BPRole bPRole)
        {
            if (ModelState.IsValid)
            {
                _context.BPRoles.Add(bPRole);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bPRole);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}