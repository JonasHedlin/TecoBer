using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TecoBerBP.DataModel;

namespace TecoBerBP.ControllerHelpers
{
    public static class UserHelper
    {
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
    }
}