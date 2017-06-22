using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TecoBerBP.Models;
using TecoBerBP.ControllersHelper;
using TecoBerBP.ViewModels;

namespace TecoBerBP.Controllers
{
    public class ActivityController : Controller
    {
        private ApplicationDbContext _context;

        public ActivityController()
        {
            _context = new ApplicationDbContext();
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;

                if (!UserHelper.IsAdminUser(user)) // Only administrator have access to this page.
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            //ActivityViewModel model = new ActivityViewModel();
            //model.Activities = _context.Activities.ToList();
            var ActivityList = _context.Activities.ToList();
            return View(ActivityList);
        }

        [HttpGet]
        public ActionResult CreateActivity()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateActivity(ActivityViewModel model)
        {
            if (User.Identity.IsAuthenticated)
            {                
                // Add new activity here!
                if (ModelState.IsValid)
                {
                    ApplicationDbContext context = new ApplicationDbContext();                    
                    var activity =  _context.Activities.Single(a => a.Id == viewModel.Activityid); // new ActivityViewModel();
                    activity.Name = model.Name;
                    activity.Duration = model.Duration;
                    activity.DurationUnit = model.DurationUnit;
                    activity.Point = model.Point;
                    context.SaveChangesAsync();
                    //context.IBPDataSource.Save();

                    ModelState.Clear();

                    ViewBag.UserMessage = "New activity created!";                    
                }
                else
                {
                    ViewBag.UserMessage = "No activity where created!";

                    return RedirectToAction("Index", "Activity");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            //model = new ActivityViewModel();
            //model.Activities = _context.Activities.ToList();
            //var ActivityList = _context.Activities.ToList();
            return View(model);
        }

    }
}