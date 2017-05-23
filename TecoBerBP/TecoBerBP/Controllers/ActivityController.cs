﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TecoBerBP.Models;


namespace TecoBerBP.Controllers
{
    public class ActivityController : Controller
    {
        private ApplicationDbContext _context;

        public ActivityController()
        {
            _context = new ApplicationDbContext();
        }
        
        // GET: Activity
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
    }
}