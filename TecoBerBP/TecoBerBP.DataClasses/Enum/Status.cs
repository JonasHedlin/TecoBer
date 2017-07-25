using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TecoBerBP.DataClasses.Enum
{    
    public enum Status
    {
        [Display(Name = "Aktiv")]
        Aktive = 1,
        [Display(Name = "Slutat")]
        Quit = 0,
        [Display(Name = "Uppehåll")]
        Paused = 10
    };
}
