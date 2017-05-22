using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using TecoBerBP.Infrastucture;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TecoBerBP
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }

        // In this method we will create default User roles and Admin user for login.
        private void CreateRolesandUsers()
        {
            BusinessPartnerDb context = new BusinessPartnerDb();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // First create Admin Role and then a default Admin User.
            if (!roleManager.RoleExists("Admin"))
            {

                // First we create Admin role.
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                // Here we create a Admin super user who will maintain the website.
                var user = new ApplicationUser();
                user.UserName = "JonasAdmin";
                user.Email = "johe@hedlin.com";

                string userPWD = "only4E7$hedlin2";

                var chkUser = UserManager.Create(user, userPWD);

                // Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }

            // Create Manager role    
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }

            // Create User role (standard user)
            if (!roleManager.RoleExists("User"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "User";
                roleManager.Create(role);
            }
        }
    }
}
