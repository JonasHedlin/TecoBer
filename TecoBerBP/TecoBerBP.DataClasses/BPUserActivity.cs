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
    public class BPUserActivity
    {
        [Key]
        public int UserActivtyId { get; set; }

        [Required]
        [DisplayName("Namn")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Datum för aktivitet")]
        public DateTime DateForActivity { get; set; }

        [DisplayName("Beskrivning")]
        public string Description { get; set; }

        [DisplayName("Affärsledare")]
        public int CompanyLeadUserId { get; set; }

        [Required]        
        public int UserId { get; set; }

        [Required]
        [DisplayName("Aktivitets-kategori")]        
        public int ActivityId { get; set; }

    }
}
