using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPDataSource
{
    public enum durationUnit { Hour, Day, Week, Month, Year};

    public class Activity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Point { get; set; }
        public virtual int Duration { get; set; }
        public virtual int DurationUnit { get; set; } // Day, Week, Month, Year
    }
}
