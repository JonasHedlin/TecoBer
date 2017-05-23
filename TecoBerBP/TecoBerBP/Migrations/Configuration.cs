namespace TecoBerBP.Migrations
{
    using BPDataSource;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TecoBerBP.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "TecoBerBP.Models.ApplicationDbContext";
        }

        protected override void Seed(TecoBerBP.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
                    
            context.Activities.AddOrUpdate(
                a => a.Name,
                new BPDataSource.Activity { Name = "Kundbesök", Duration = 12, DurationUnit = (int)durationUnit.Month, Point = 1 },
                new BPDataSource.Activity { Name = "Kundmottagning", Duration = 12, DurationUnit = 3, Point = 1 },
                new BPDataSource.Activity { Name = "Kundevent", Duration = 12, DurationUnit = 3, Point = 1 },
                new BPDataSource.Activity { Name = "Konsultrekrytering", Duration = 12, DurationUnit = 3, Point = 1 },
                new BPDataSource.Activity { Name = "Internuppdrag", Duration = 12, DurationUnit = 3, Point = 2 }
                );
        }
    }
}
