using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TecoBerBP.DataClasses
{
    public class BPManagement
    {
        [Key]
        public int ManagementId { get; set; }

        public int UserId { get; set; }

    }
}
