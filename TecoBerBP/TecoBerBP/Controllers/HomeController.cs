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
            string userName = User.Identity.Name;
            int userId = UserHelper.GetUserID(userName);
            this.ViewBag.UserId = userId;

            return View();
        }

     

        public ActionResult About()
        {
            ViewBag.Message = "Berotec Business Partner Portal";

            string userName = User.Identity.Name;
            int userId = UserHelper.GetUserID(userName);
            this.ViewBag.UserId = userId;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontaktuppgifter";

            string userName = User.Identity.Name;
            int userId = UserHelper.GetUserID(userName);
            this.ViewBag.UserId = userId;

            return View();
        }
    }
}