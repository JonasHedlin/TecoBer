using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TecoBerBP.DataClasses.Enum
{
    public enum Gender
    {        
        [Display(Name = "Kvinna")]
        Female = 0,
        [Display(Name = "Man")]
        Male = 1
    };
}
