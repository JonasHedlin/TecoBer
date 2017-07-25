using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TecoBerBP.DataModel;

namespace TecoBerBP.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string userName = User.Identity.Name;
            int userId = GetUserID(userName);
            this.ViewBag.UserId = userId;

            return View();
        }

        private int GetUserID(string userName)
        {
            // Implement Linq to fetch real id here!
            int UserID = 0;                        

            using (TecoBerBPContext TBBPC = new TecoBerBPContext())
            {
                var userId = from u in TBBPC.BPUsers
                             where u.Email == userName
                             select u.UserId;

                var UserId = userId.FirstOrDefault<int>();

                if (userId != null)                    
                    UserID = (int)UserId;

            }

            return UserID;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}