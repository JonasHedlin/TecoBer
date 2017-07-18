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
        public virtual int Id { get; set; }

        [DisplayName("Namn")]
        public virtual string Name { get; set; }

        [DisplayName("Poäng")]
        public virtual int Point { get; set; }

        [DisplayName("Varaktighet")]
        public virtual int Duration { get; set; }

        [DisplayName("Enhet")]
        public virtual int DurationUnit { get; set; } // Day, Week, Month, Year
    }
}
