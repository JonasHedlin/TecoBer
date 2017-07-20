using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TecoBerBP.DataClasses.Enum
{
    public enum DurationUnit {
        [Display(Name = "Timmar")]
        Hour,
        [Display(Name = "Dagar")]
        Day,
        [Display(Name = "Veckor")]
        Week,
        [Display(Name = "Månader")]
        Month,
        [Display(Name = "År")]
        Year
    };

}
