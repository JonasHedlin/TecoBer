using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TecoBerBP.Models;


namespace TecoBerBP.Controllers
{
    public class ActivityController : Controller
    {
        private xxx _context;

        public ActivityController()
        {
            _context = new xxx();
        }
        
        // GET: Activity
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                

                
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            var Activity = _context.Activity.ToList();
            return View(Activity);
        }
    }
}