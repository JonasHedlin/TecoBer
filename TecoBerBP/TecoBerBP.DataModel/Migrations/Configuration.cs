namespace TecoBerBP.DataModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TecoBerBP.DataModel.TecoBerBPContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

        }

        protected override void Seed(TecoBerBP.DataModel.TecoBerBPContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            context.BPRoles.AddOrUpdate(
              p => p.Name,
              new DataClasses.BPRole { Name = "Administratör", AuthenticationLevel = 10 },
              new DataClasses.BPRole { Name = "Ekonom", AuthenticationLevel = 5 },
              new DataClasses.BPRole { Name = "Användare", AuthenticationLevel = 1 }
            );



        }
    }
}
