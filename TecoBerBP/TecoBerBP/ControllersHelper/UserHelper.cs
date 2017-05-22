using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using TecoBerBP.Infrastucture;

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
                BusinessPartnerDb context = new BusinessPartnerDb();
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