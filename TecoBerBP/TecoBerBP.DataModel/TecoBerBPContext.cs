﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TecoBerBP.DataClasses;

namespace TecoBerBP.DataModel
{
    public class TecoBerBPContext: DbContext
    {
        public DbSet<BPActivity> BPActivities { get; set; }
        public DbSet<BPUser> BPUsers { get; set; }
        public DbSet<BPRole> BPRoles { get; set; }

    }
}
