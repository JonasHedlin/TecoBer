using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TecoBerBP.DataClasses.Enum;

namespace TecoBerBP.DataClasses
{    
    public class BPActivity
    {
        private EnDurationUnit _durationUnit = Enum.EnDurationUnit.Month;
        private int _point = 1;
        private int _duration = 12;

        [Key]
        public int ActivityId { get; set; }

        [DisplayName("Namn")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Poäng")]
        public int Point
        {
            get { return _point; }
            set => _point = value;
        }

        [DisplayName("Varaktighet")]
        public int Duration
        {
            get { return _duration; }
            set => _duration = value; 
        }

        //[DisplayName("Enhet")]
        //public virtual int DurationUnit { get; set; } // Day, Week, Month, Year

        [DisplayName("Enhet")]
        [EnumDataType(typeof(EnDurationUnit))]
        public EnDurationUnit? DurationUnit
        {
            get { return _durationUnit; }
            set => _durationUnit = (EnDurationUnit)value;
        }

        public virtual ICollection<BPUser> BPUsers { get; set; }


    }
}
