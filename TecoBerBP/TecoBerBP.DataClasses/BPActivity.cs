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
        private DurationUnit _durationUnit = Enum.DurationUnit.Month;
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
        [EnumDataType(typeof(DurationUnit))]
        public DurationUnit? DurationUnit
        {
            get { return _durationUnit; }
            set => _durationUnit = (DurationUnit)value;
        }

    }
}
