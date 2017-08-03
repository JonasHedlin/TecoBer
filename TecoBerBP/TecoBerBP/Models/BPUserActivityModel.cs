using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TecoBerBP.DataModel;
using TecoBerBP.ViewModels;


namespace TecoBerBP.Models
{
    public class BPUserActivityModel
    {
        TecoBerBPContext TBBPC; // = new TecoBerBPContext();
        List<UserActivityViewModel> _userActivityList = new List<UserActivityViewModel>();

        /// <summary>
        /// Use this class then the view need to show combined data for all activities for one user.
        /// </summary>
        public BPUserActivityModel(int userId)
        {
            using (TBBPC = new TecoBerBPContext())
            {
                _userActivityList = (from ua in TBBPC.BPUserActivities
                                     join u in TBBPC.BPUsers on ua.CompanyLeadUserId equals u.UserId
                                     join a in TBBPC.BPActivities on ua.ActivityId equals a.ActivityId
                                     where ua.UserId == userId
                                     select new UserActivityViewModel
                                     {
                                         UserActivityId = ua.UserActivityId,
                                         Name = ua.Name,
                                         DateForActivity = ua.DateForActivity,
                                         Description = ua.Description,
                                         CompanyLead = u.Name + " " + u.SurName,
                                         Activity = a.Name
                                     }).ToList();
            
            }

        }

        internal object UserActivityList()
        {
            return _userActivityList;
        }
    }
}