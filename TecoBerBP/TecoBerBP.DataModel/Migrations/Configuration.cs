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

                // Import data (user data) from excel sheet.
                ImportExcelDataClass IEDC = new ImportExcelDataClass();

                List<BerotecUserClass> BUsers = IEDC.GetExcelData();

                foreach (BerotecUserClass BUser in BUsers)
                {
                    context.BPUsers.AddOrUpdate(
                      u => u.Name,
                      new DataClasses.BPUser
                      {
                          Name = BUser.Name,
                          SurName = BUser.SurName,
                          Gender = (Gender)(BUser.Gender == "M" ? 1 : (BUser.Gender == "K" ? 0 : 10)), // a ? b : (c ? d : e)
                          Email = BUser.Email,
                          AltEmail = BUser.AltEmail,
                          Titel = BUser.Titel,
                          AreaOfExpertise = BUser.AreaOfExpertise,
                          Cell = ((BUser.Cell).Replace("-", "")).Replace(" ", ""), // No space ' ' or '-' chars in phone number.
                          Company = BUser.Company,
                          CompanyNo = BUser.CompanyNo,
                          CompanyAddress = BUser.CompanyAddress,
                          CompanyZip = BUser.CompanyZip,
                          CompanyCity = BUser.CompanyCity,
                          OfficeLocation = BUser.OfficeLocation,
                          CompanyLead = BUser.CompanyLead,
                          DateOfBirth = BUser.DateOfBirth,
                          JoinedDate = BUser.JoinedDate,
                          QuitDate = BUser.QuitDate,
                          Comment = BUser.Comment,
                          Status = (Status)(BUser.Status == "Aktiv" ? 1 : (BUser.Status == "Slutat" ? 0 : 10)),
                          RoleId = AuthenticationLevel.User // (1) Always start as user (standard user).
                      }
                    );
                }
                //context.SaveChanges();
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
