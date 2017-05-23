using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TecoBerBP.Models;
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
                // Do whats need to be done when user is authenticated and want to see the activity list.

                

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            var ActivityList = _context.Activities.ToList();
            return View(ActivityList);
        }

        [HttpPost]
        public ActionResult Index(ActivityViewModel model)
        {
            if (User.Identity.IsAuthenticated)
            {                
                // Add new activity here!
                if (ModelState.IsValid)
                {
                    ApplicationDbContext context = new ApplicationDbContext();                    
                    var activity = new ActivityViewModel(); // _context.Activities.Single(a => a.Id == viewModel.Activityid);
                    activity.Name = model.Name;
                    activity.Duration = model.Duration;
                    activity.DurationUnit = model.DurationUnit;
                    activity.Point = model.Point;
                    context.SaveChanges();                    

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

            var ActivityList = _context.Activities.ToList();
            return View(ActivityList);
        }

    }
}