using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecoBerBP.Models
{
    public class UserActivity
    {
        public int ActivityId { get; set; }
        public int UserId { get; set; }
        public DateTime ActivityDate { get; set; }
        public DateTime EndDate { get; set; }
        
    }
}
