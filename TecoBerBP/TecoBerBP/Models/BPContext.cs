﻿
//using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecoBerBP.Models
{
    public class BPContext /*: DbContext*/
    {
        //private IConfigurationRoot _config;

        public BPContext(/*IConfigurationRoot config, DbContextOptions options*/) //: base()
        {
            //_config = config;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Activity> Activities { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    optionsBuilder.UseSqlServer(_config["ConnectionStrings:DefaultConnectionString"]);
        //}

        //public async SaveChangesAsync()
        //{

        //}

    }
}
