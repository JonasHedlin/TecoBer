using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web;
using System.Web.Mvc;
using TecoBerBP.ControllersHelper;
using TecoBerBP.Infrastucture;
using TecoBerBP.ViewModels;

namespace TecoBerBP.Controllers
{
    public class RoleController : Controller
    {
        private BusinessPartnerDb _context;

        public RoleController()
        {
            _context = new BusinessPartnerDb();
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
                BusinessPartnerDb context = new BusinessPartnerDb();
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = model.Name;
                roleManager.Create(role);

                ModelState.Clear();

                ViewBag.UserMessage = "New role created!";
            }

            return View("CreateRole");
        }

        //// GET: Role
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}