using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecoBerBP.Models;

namespace TecoBerBP.Infrastucture
{
    public interface IBPDataSource
    {
        //IQueryable<User> Users{ get; }
        //IQueryable<Role> Roles { get; }
        IQueryable<Activity> Activities { get; }
    }
}
