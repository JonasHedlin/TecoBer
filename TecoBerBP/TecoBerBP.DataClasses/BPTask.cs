using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecoBerBP.DataClasses
{
    public class BPTask
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Comment { get; set; }
        public virtual int Point { get; set; }
        public virtual DateTime Date { get; set; }

    }
}
