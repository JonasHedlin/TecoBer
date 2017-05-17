using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TecoBerBP.Models;

namespace TecoBerBP.Infrastucture
{
    public class BuisinesPartnerDb : DbContext, IBPDataSource
    {
        public BuisinesPartnerDb() : base("DefaultConnection")
        {

        }


        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities { get; set; }

        IQueryable<Role> IBPDataSource.Roles
        {
            get { return Roles; } //throw new NotImplementedException();
        }

        IQueryable<User> IBPDataSource.Users
        {
            get { return Users; } // throw new NotImplementedException();
        }

        IQueryable<Activity> IBPDataSource.Activities
        {
            get { return Activities; } // throw new NotImplementedException();
        }

    }
}