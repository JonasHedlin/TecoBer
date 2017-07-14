using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPDataSource
{
    public interface IBPDataSource
    {
        IQueryable<Activity> Activities { get; } // activities
        IQueryable<BPUser> BPUsers { get; } // Berotec users

        void Save();

    }
}
