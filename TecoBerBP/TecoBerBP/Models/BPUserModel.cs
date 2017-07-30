using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TecoBerBP.DataModel;
using TecoBerBP.ViewModels;

namespace TecoBerBP.Models
{
    public class BPUserModel
    {
        TecoBerBPContext TBBPC; // = new TecoBerBPContext();
        List<UserViewModel> _userList = new List<UserViewModel>();

        /// <summary>
        /// Use this class then the view only need to show this data: Name, Email, Cell, Company, CompanyCity, CompanyLead, OfficeLocation.
        /// </summary>
        public BPUserModel()
        {
            using (TBBPC = new TecoBerBPContext())
            {
                _userList = TBBPC.BPUsers.Select(u => new UserViewModel
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
        }        

        internal object UserList()
        {
            return _userList;
        }        
        
    }
}