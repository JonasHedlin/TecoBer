using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TecoBerBP.DataModel;
using TecoBerBP.ControllerHelpers;

namespace TecoBerBP.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {            
            this.ViewBag.UserId = UserHelper.GetUserID(User.Identity.Name);

            return View();
        }

     

        public ActionResult About()
        {
            ViewBag.Message = "Berotec Business Partner Portal";

            this.ViewBag.UserId = UserHelper.GetUserID(User.Identity.Name);

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontaktuppgifter";

            this.ViewBag.UserId = UserHelper.GetUserID(User.Identity.Name);

            return View();
        }
    }
}