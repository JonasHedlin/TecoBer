using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecoBerBP.DataClasses
{
    public class BPTask
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Comment { get; set; }

        public int Point { get; set; }

        public DateTime Date { get; set; }

    }
}
