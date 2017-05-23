using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TecoBerBP.Models;
using TecoBerBP.ControllersHelper;
using TecoBerBP.ViewModels;

namespace TecoBerBP.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private ApplicationDbContext _context;

        public RoleController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;

                if (!UserHelper.IsAdminUser(user))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            var Roles = _context.Roles.ToList();
            return View(Roles);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("CreateRole");
        }

        [HttpPost]
        public ActionResult Create(RoleViewModel model)
        {
            // Add new role here!
            if (ModelState.IsValid)
            {
                ApplicationDbContext context = new ApplicationDbContext();
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole(); // object with id created.
                role.Name = model.Name;
                roleManager.Create(role);

                ModelState.Clear();

                ViewBag.UserMessage = "New role created!";
            }

            return View("CreateRole");
        }

    }
}