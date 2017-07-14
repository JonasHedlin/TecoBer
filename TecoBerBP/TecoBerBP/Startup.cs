using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TecoBerBP.Models;


[assembly: OwinStartupAttribute(typeof(TecoBerBP.Startup))]
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
            ApplicationDbContext context = new ApplicationDbContext();

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
                user.Email = "jonas.hedlin@berotec.se";
                user.UserName = user.Email;

                string userPWD = "only4E7$hedlin";

                var chkUser = UserManager.Create(user, userPWD);

                // Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }

            // Create Economist role    
            if (!roleManager.RoleExists("Economist"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Economist";
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
