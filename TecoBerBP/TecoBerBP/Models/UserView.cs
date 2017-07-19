using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TecoBerBP.Models
{
    public class UserView
    {
        public int UserId { get; set; }

        [DisplayName("Namn")]
        public string Name { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Mobil")]
        public string Cell { get; set; }

        [DisplayName("Företag")]
        public string Company { get; set; }

        [DisplayName("Stad")]
        public string CompanyCity { get; set; }

        [DisplayName("Kontorets placering")]
        public string OfficeLocation { get; set; }

        [DisplayName("Affärsledare")]
        public string CompanyLead { get; set; }
    }
}