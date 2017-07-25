using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TecoBerBP.DataClasses.Enum
{
    public enum EnAuthenticationLevel
    {
        [Display(Name = "Användare")]
        User = 1,
        [Display(Name = "Ekonom")]
        Economist = 5,
        [Display(Name = "Administratör")]
        Admin = 10
    };
}
