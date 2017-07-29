namespace TecoBerBP.DataModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ImportDataFromExcelClassLibrary;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using TecoBerBP.DataClasses.Enum;

    internal sealed class Configuration : DbMigrationsConfiguration<TecoBerBP.DataModel.TecoBerBPContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true; // TODO: Change this, only during development!

            // Activate debugger! (will open in new VS instance)
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //{

            //    System.Diagnostics.Debugger.Launch();

            //}
        }

        protected override void Seed(TecoBerBP.DataModel.TecoBerBPContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            try
            {
                context.BPRoles.AddOrUpdate(
                  p => p.Name,
                  new DataClasses.BPRole { Name = "Administratör", AuthenticationLevel = 10 },
                  new DataClasses.BPRole { Name = "Ekonom", AuthenticationLevel = 5 },
                  new DataClasses.BPRole { Name = "Användare", AuthenticationLevel = 1 }
                );


                context.BPActivities.AddOrUpdate(
                    ua => ua.ActivityId,
                    new DataClasses.BPActivity { Name = "Findings - hos kun", Duration = 12, DurationUnit = EnDurationUnit.Month, Point = 1 },
                    new DataClasses.BPActivity { Name = "Arbetsmarknadsdag - Anordna", Duration = 12, DurationUnit = EnDurationUnit.Month, Point = 1 },
                    new DataClasses.BPActivity { Name = "Arbetsmarknadsdag - Hjälpa till", Duration = 12, DurationUnit = EnDurationUnit.Month, Point = 1 },
                    new DataClasses.BPActivity { Name = "Be Orange nivaå 2-6 - Deltaga", Duration = 12, DurationUnit = EnDurationUnit.Month, Point = 1 },
                    new DataClasses.BPActivity { Name = "Be Orange Refresh - Deltaga", Duration = 12, DurationUnit = EnDurationUnit.Month, Point = 1 },
                    new DataClasses.BPActivity { Name = "Berotec Säljutbildning - Deltaga", Duration = 12, DurationUnit = EnDurationUnit.Month, Point = 1 },
                    new DataClasses.BPActivity { Name = "Berotecträff - Anordna", Duration = 12, DurationUnit = EnDurationUnit.Month, Point = 1 },
                    new DataClasses.BPActivity { Name = "Blogga", Duration = 12, DurationUnit = EnDurationUnit.Month, Point = 1 },
                    new DataClasses.BPActivity { Name = "Extern kurs - Deltaga", Duration = 12, DurationUnit = EnDurationUnit.Month, Point = 1 },
                    new DataClasses.BPActivity { Name = "Etern utbildning med Berotec-koppling - Anordna", Duration = 12, DurationUnit = EnDurationUnit.Month, Point = 1 },
                    new DataClasses.BPActivity { Name = "Externa seminarium med Berotec-koppling - Anordna", Duration = 12, DurationUnit = EnDurationUnit.Month, Point = 1 },
                    new DataClasses.BPActivity { Name = "Förmedling av personlig kontakt", Duration = 12, DurationUnit = EnDurationUnit.Month, Point = 1 },
                    new DataClasses.BPActivity { Name = "Intern utbildning - Anordna", Duration = 12, DurationUnit = EnDurationUnit.Month, Point = 1 },
                    new DataClasses.BPActivity { Name = "Interna seminarium - Anordna", Duration = 12, DurationUnit = EnDurationUnit.Month, Point = 1 },
                    new DataClasses.BPActivity { Name = "Kompetensgrupp - Äga/Driva", Duration = 12, DurationUnit = EnDurationUnit.Month, Point = 1 },
                    new DataClasses.BPActivity { Name = "Konferansresa anordna i Berotecs regi - Anordna", Duration = 12, DurationUnit = EnDurationUnit.Month, Point = 1 },
                    new DataClasses.BPActivity { Name = "Konferansresa anordnad i Berotecs regi - Deltaga", Duration = 12, DurationUnit = EnDurationUnit.Month, Point = 1 },
                    new DataClasses.BPActivity { Name = "Kundcase - Skapa", Duration = 12, DurationUnit = EnDurationUnit.Month, Point = 1 },
                    new DataClasses.BPActivity { Name = "Kundevent - Anordna", Duration = 12, DurationUnit = EnDurationUnit.Month, Point = 1 },
                    new DataClasses.BPActivity { Name = "Kundmöte - Deltaga med unik kompetens", Duration = 12, DurationUnit = EnDurationUnit.Month, Point = 1 }
                    );


                // Import data (user data) from excel sheet.
                //ImportExcelDataClass IEDC = new ImportExcelDataClass();

                //List<BerotecUserClass> BUsers = IEDC.GetExcelData();

                //foreach (BerotecUserClass BUser in BUsers)
                //{
                //    context.BPUsers.AddOrUpdate(
                //      u => u.CLSID,
                //      new DataClasses.BPUser
                //      {
                //          Name = BUser.Name,
                //          SurName = BUser.SurName,
                //          CLSID = string.IsNullOrEmpty(BUser.CLSID) == true ? Guid.NewGuid().ToString() : BUser.CLSID, // TODO! Must change so that we have this field in the excel-sheet to and only generate a new Guid if that field is empty!
                //          Gender = (EnGender)(string.IsNullOrEmpty(BUser.Gender) == false ? (BUser.Gender == "M" ? 1 : (BUser.Gender == "K" ? 0 : 10)) : 10), // a ? b : (c ? d : e)
                //          Email = BUser.Email,
                //          AltEmail = BUser.AltEmail,
                //          Titel = BUser.Titel,
                //          AreaOfExpertise = BUser.AreaOfExpertise,
                //          Cell = string.IsNullOrEmpty(BUser.Cell) == false ? ((BUser.Cell).Replace("-", "")).Replace(" ", "") : "", // No space ' ' or '-' chars in phone number.
                //          Company = BUser.Company,
                //          CompanyNo = BUser.CompanyNo,
                //          CompanyAddress = BUser.CompanyAddress,
                //          CompanyZip = BUser.CompanyZip,
                //          CompanyCity = BUser.CompanyCity,
                //          OfficeLocation = BUser.OfficeLocation,
                //          CompanyLead = BUser.CompanyLead,
                //          DateOfBirth = BUser.DateOfBirth,
                //          JoinedDate = BUser.JoinedDate,
                //          QuitDate = BUser.QuitDate,
                //          Comment = BUser.Comment,
                //          Status = (EnStatus)(BUser.Status == "Aktiv" ? 1 : (BUser.Status == "Slutat" ? 0 : 10)),
                //          RoleId = EnAuthenticationLevel.User // (1) Always start as user (standard user).
                //      }
                //    );
                //}

                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

        }
        
    }
}
