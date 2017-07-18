using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TecoBerBP.DataClasses
{    
    public class BPActivity
    {
        [Key]
        public virtual int ActivityId { get; set; }

        [DisplayName("Namn")]
        [Required]
        public virtual string Name { get; set; }

        [DisplayName("Poäng")]
        public virtual int Point { get; set; }

        [DisplayName("Varaktighet")]
        public virtual int Duration { get; set; }

        [DisplayName("Enhet")]
        public virtual int DurationUnit { get; set; } // Day, Week, Month, Year
    }
}
