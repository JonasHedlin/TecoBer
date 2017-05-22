using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TecoBerBP.Models;

namespace TecoBerBP.Infrastucture
{
    public class BusinessPartnerDb : IdentityDbContext<ApplicationUser>, IBPDataSource // DbContext
    {
        public BusinessPartnerDb() : base("DefaultConnection")
        {

        }

        //public DbSet<Role> Roles { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities { get; set; }

        //IQueryable<Role> IBPDataSource.Roles
        //{
        //    get { return Roles; } //throw new NotImplementedException();
        //}

        //IQueryable<User> IBPDataSource.Users
        //{
        //    get { return Users; } // throw new NotImplementedException();
        //}

        IQueryable<Activity> IBPDataSource.Activities
        {
            get { return Activities; } // throw new NotImplementedException();
        }

    }

    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }

}