using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TecoBerBP.DataClasses
{
    public class BPUser
    {
        public virtual int Id { get; set; }

        public virtual string NetUserId { get; set; }

        [DisplayName("Namn")]
        public virtual string Name { get; set; }

        [DisplayName("e-mail")]
        public virtual string Email { get; set; }

        [DisplayName("Alternativ e-mail")]
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

        [DisplayName("Kontorets placering")]
        public virtual string OfficeLocation { get; set; }

        [DisplayName("Affärsledare")]
        public virtual string CompanyLead { get; set; }
        
    }
}
