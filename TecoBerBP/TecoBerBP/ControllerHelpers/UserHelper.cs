using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TecoBerBP.DataModel;
using TecoBerBP.DataClasses.Enum;

namespace TecoBerBP.ControllerHelpers
{
    public static class UserHelper
    {
        /// <summary>
        /// Get user ID from database for logged in user. (Office 365 uses users e-mail as logged in name)
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static int GetUserID(string userName)
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

        /// <summary>
        /// Check if logged in user is in role Administrator.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>True if logged in user is an Administrator.</returns>
        public static bool IsUserAdmin(string userName)
        {
            bool isAdmin = false;

            using (TecoBerBPContext TBBPC = new TecoBerBPContext())
            {
                var roleID = from u in TBBPC.BPUsers
                             where u.Email == userName
                             select u.RoleId;

                foreach(EnAuthenticationLevel EnAu in roleID) // Should only be one item in list.
                {
                    if (EnAu == EnAuthenticationLevel.Admin)
                        isAdmin = true;
                }
            }

            return isAdmin;
        }
    }
}