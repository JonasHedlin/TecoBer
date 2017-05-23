using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Web.Mvc;
using TecoBerBP.Models;

namespace TecoBerBP.ControllersHelper
{
    public static class UserHelper
    {
        [Authorize]
        public static Boolean IsAdminUser(IIdentity user)
        {
            if (user.IsAuthenticated) // User.Identity.IsAuthenticated
            {
                //var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}