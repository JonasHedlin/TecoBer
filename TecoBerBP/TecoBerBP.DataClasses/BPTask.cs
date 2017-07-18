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
        public virtual int TaskId { get; set; }

        public virtual string Name { get; set; }
        public virtual string Comment { get; set; }
        public virtual int Point { get; set; }
        public virtual DateTime Date { get; set; }

    }
}
