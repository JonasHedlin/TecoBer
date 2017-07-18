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
        public virtual int Id { get; set; }

        [DisplayName("Namn")]
        public virtual string Name { get; set; }

        [DisplayName("Rättighetsnivå")]
        public virtual int AuthenticationLevel { get; set; }

    }
}
