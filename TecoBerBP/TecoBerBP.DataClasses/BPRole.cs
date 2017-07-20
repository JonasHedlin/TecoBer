using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TecoBerBP.DataClasses
{
    public class BPRole
    {
        [Key]
        public int RoleId { get; set; }

        [DisplayName("Namn")]
        [Required]
        public string Name { get; set; }

        [Range(1,10)]
        [DisplayName("Rättighetsnivå")]
        [Required]
        public int AuthenticationLevel { get; set; }

    }
}
