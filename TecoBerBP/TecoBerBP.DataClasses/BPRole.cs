using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecoBerBP.DataClasses
{
    public class BPRole
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int AuthenticationLevel { get; set; }
    }
}
