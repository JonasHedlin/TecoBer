using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TecoBerBP.DataModel;
using TecoBerBP.Models;

namespace TecoBerBP.ViewModels
{
    public class BPUserViewModel
    {
        TecoBerBPContext TBBPC = new TecoBerBPContext();
        List<UserView> _userList = new List<UserView>();

        public BPUserViewModel()
        {
            _userList = TBBPC.BPUsers.Select(u => new UserView
            {
                UserId = u.UserId,
                Name = u.Name + " " + u.SurName,
                Email = u.Email,
                Cell = u.Cell,
                Company = u.Company,
                CompanyCity = u.CompanyCity,
                CompanyLead = u.CompanyLead,
                OfficeLocation = u.OfficeLocation
            }).ToList();
                
        }        

        internal object UserList()
        {
            return _userList;
        }        
        
    }
}