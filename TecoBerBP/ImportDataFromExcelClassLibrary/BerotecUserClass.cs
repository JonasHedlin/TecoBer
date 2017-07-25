using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportDataFromExcelClassLibrary
{
    public class BerotecUserClass
    {
        public string Name { get; set; } // FÖRNAMN
        public string SurName { get; set; } // EFTERNAMN
        public string Gender { get; set; } // Kön
        public string Email { get; set; } // Berotec MAILADRESS
        public string AltEmail { get; set; } // ALTERNATIV MAILADRESS
        public string Titel { get; set; } // Titel
        public string AreaOfExpertise { get; set; } // Verksamhetsområde
        public string Cell { get; set; } // Mobil
        public string Company { get; set; } // Företagsnamn
        public string CompanyNo { get; set; } // Org.Nr
        public string CompanyAddress { get; set; } // Företagsadress
        public string CompanyZip { get; set; } // PostNr
        public string CompanyCity { get; set; } // Ort
        public string OfficeLocation { get; set; } // Kontor
        public string CompanyLead { get; set; } // AffärsLedare
        public string DateOfBirth { get; set; } // Födelsedatum / Född        
        public string JoinedDate { get; set; } // Startdatum
        public string QuitDate { get; set; } // Slutdatum
        public string Comment { get; set; } // Kommentar
        public string Status { get; set; } // Aktiv, Vilande, Har slutat (status).
        public string CLSID { get; set; } // Unique generated ID, Guid.
    }
}
