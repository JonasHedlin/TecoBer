using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecoBerBP.DataClasses
{
    public class BPUser
    {
        [Key]
        public virtual int UserId { get; set; }

        [DisplayName("NET user Id")]
        public virtual string NetUserId { get; set; }

        [DisplayName("Förnamn")]
        public virtual string Name { get; set; }

        [DisplayName("Efternamn")]
        public virtual string SurName { get; set; }

        [DisplayName("Kön")]
        public virtual string Gender { get; set; }

        [DisplayName("e-mail")]
        [DataType(DataType.EmailAddress)]
        public virtual string Email { get; set; }

        [DisplayName("Alternativ e-mail")]
        [DataType(DataType.EmailAddress)]
        public virtual string AltEmail { get; set; }

        [DisplayName("Titel")]
        public virtual string Titel { get; set; }

        [DisplayName("Verksamhetsområde")]
        public virtual string AreaOfExpertise { get; set; }

        [DisplayName("Mobil")]
        public virtual string Cell { get; set; }

        [DisplayName("Företag")]
        public virtual string Company { get; set; }

        [DisplayName("Organisationsnummer")]
        public virtual string CompanyNo { get; set; }

        [DisplayName("Adress")]
        public virtual string CompanyAddress { get; set; }

        [DisplayName("Postnummer")]
        public virtual string CompanyZip { get; set; }

        [DisplayName("Företagets stad")]
        public virtual string CompanyCity { get; set; }

        [DisplayName("Affärsledare")]
        public virtual string CompanyLead { get; set; }

        [DisplayName("Kontorets placering")]
        public virtual string OfficeLocation { get; set; }

        [DisplayName("Födelsedatum")]
        public virtual string DateOfBirth { get; set; }

        [DisplayName("Startdatum")]
        public virtual string JoinedDate { get; set; }

        [DisplayName("Slutdatum")]
        public virtual string QuitDate { get; set; }        

        [DisplayName("Kommentar")]
        public virtual string Comment { get; set; }

        [DisplayName("Status")]
        public virtual string Status { get; set; }

        
        public virtual int RoleId { get; set; }

        public virtual ICollection<BPActivity> BPActivites { get; set; }

    }
}
