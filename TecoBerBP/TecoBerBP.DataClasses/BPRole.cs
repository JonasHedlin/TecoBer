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
        public virtual int RoleId { get; set; }

        [DisplayName("Namn")]
        public virtual string Name { get; set; }

        [Range(1,10)]
        [DisplayName("Rättighetsnivå")]
        public virtual int AuthenticationLevel { get; set; }

    }
}
