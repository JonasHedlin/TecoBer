//using LinqToExcel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using Microsoft.Examples.LtxOpenXml;


namespace ImportDataFromExcelClassLibrary
{
    public class ImportExcelDataClass
    {
        private string _filePaht;
        private string m_MessageLog;

#if DEBUG
        public ImportExcelDataClass()
        {
            // Default file location - only during debug!
            _filePaht = "C:\\Users\\Jonas\\OneDrive\\Documents\\WorkFlowIT\\Berotec\\NET uppdrag\\Konsultlistan Berotec 2.xlsx";
        }
#endif
        public ImportExcelDataClass(string FilePath)
        {
            _filePaht = FilePath;
        }

        /// <summary>
        /// Import data from the given excel data file (FilePath must have been set first!) and returns all users in a list.
        /// </summary>        
        /// <returns>A list of users.</returns>
        public List<BerotecUserClass> GetExcelData()
        {
            // first get 'Aktiva konsulter'
            List<BerotecUserClass> BUC = GetExcelData("AktivaKonsulter");

            // and then get 'konsulter som slutat'
            BUC.AddRange(GetExcelData("Konsulter_slutat"));

            return BUC;
        }

        /// <summary>
        /// Get last error that occurred in this class.
        /// </summary>
        /// <returns>Error message.</returns>
        public string GetLastError()
        {
            return m_MessageLog;
        }
        
        private List<BerotecUserClass> GetExcelData(string Status)
        {
            try
            {
                List<BerotecUserClass> BUC = new List<BerotecUserClass>();

                #region Using LinqToExcel
                //DataSet ds = new DataSet(_filePaht);
                //var excel = new ExcelQueryFactory(_filePaht);

                //excel.AddMapping<BerotecUserClass>(x => x.Name, "FÖRNAMN_(FirstName)"); //maps the "Email" property to the "ALTERNATIV MAILADRESS" column.
                //excel.AddMapping("SurName", "EFTERNAMN _(LastName)");
                //excel.AddMapping("Email", "BEROTECMAILADRESS_(UserPrincipalName)");
                //excel.AddMapping("AltEmail", "ALTERNATIV MAILADRESS_(AlternateEmailAddresses)");
                //excel.AddMapping("Titel", "TITEL_(Title)");
                //excel.AddMapping("AreaOfExpertise", "VERKSAMHETSOMRÅDE_(Custom1)");
                //excel.AddMapping("Cell", "MOBIL _(MobilePhone)");
                //excel.AddMapping("Company", "FÖRETAGSNAMN_(Custom2)");
                //excel.AddMapping("CompanyNo", "ORG#NR_(Custom3)");
                //excel.AddMapping("CompanyAddress", "FÖRETAGSADRESS _(StreetAddress)");
                //excel.AddMapping("CompanyZip", "POSTNR_(PostalCode)");
                //excel.AddMapping("CompanyCity", "ORT_(City)");
                //excel.AddMapping("OfficeLocation", "KONTOR_(Office)");
                //excel.AddMapping("CompanyLead", "AFFÄRS-_LEDARE_(Department)");
                //excel.AddMapping("DateOfBirth", "FÖDD");                
                //excel.AddMapping("JoinedDate", "START DATUM");
                //excel.AddMapping("QuitDate", "Slutdatum");
                //excel.AddMapping("Comment", "KOMMENTAR");
                //excel.AddMapping("Status", "Status");

                //var AllBerotecUsers = from c in excel.Worksheet<BerotecUserClass>("AllaBerotecare") //worksheet name = 'AllaBerotecare' // "Business Portal"
                //                      select c; //where c.OfficeLocation == "Göteborg"

                #endregion Using LinqToExcel

                using (SpreadsheetDocument spreadsheet = SpreadsheetDocument.Open(_filePaht, false))
                {
                    
                var AllBerotecUsers = from c in spreadsheet.Table(Status).TableRows() //worksheet name = 'AllaBerotecare' // "Business Portal" // AktivaKonsulter/Konsulter_Slutat
                                      select new BerotecUserClass() //where c.OfficeLocation == "Göteborg"
                                          {
                                              Name = (string)c["FÖRNAMN"],
                                              SurName = (string)c["EFTERNAMN"],
                                              Gender = (string)c["Gender"],
                                              Email = (string)c["BEROTECMAILADRESS"],
                                              AltEmail = (string)c["ALTERNATIV MAILADRESS"],
                                              Titel = (string)c["TITEL"],
                                              AreaOfExpertise = (string)c["VERKSAMHETSOMRÅDE"],
                                              Cell = (string)c["MOBIL"],
                                              Company = (string)c["FÖRETAGSNAMN"],
                                              CompanyNo = (string)c["ORGNR"],
                                              CompanyAddress = (string)c["FÖRETAGSADRESS"],
                                              CompanyZip = (string)c["POSTNR"],
                                              CompanyCity = (string)c["ORT"],
                                              OfficeLocation = (string)c["KONTOR"],
                                              CompanyLead = (string)c["AFFÄRSLEDARE"],
                                              DateOfBirth = (string)c["FÖDD"],
                                              JoinedDate = (string)c["STARTDATUM"],
                                              QuitDate = (string)c["Slutdatum"],
                                              Comment = (string)c["KOMMENTAR"],
                                              Status = (string)c["Status"]
                                          };


                    foreach (var bec in AllBerotecUsers) // BerotecUserClass
                    {
                        if(Status == "Konsulter_slutat")
                            bec.Status = "Slutat";
                        else if (Status == "AktivaKonsulter")
                            bec.Status = "Aktiv";

                        if (bec.Name == "FÖRNAMN")
                            continue; // Dont save column names!

                        BUC.Add(bec);
                    }
                }
                return BUC;
            }
            catch(Exception e)
            {
                m_MessageLog = e.Message;
                throw e;
            }

        }
    }
}
