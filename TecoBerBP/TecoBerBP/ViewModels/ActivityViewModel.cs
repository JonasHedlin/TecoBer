using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BPDataSource;
using System.ComponentModel;

namespace TecoBerBP.ViewModels
{
    public class ActivityViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Point { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        [DisplayName("Duration Unit")]
        public string DurationUnit { get; set; }

        //public IEnumerable<Activity> Activities { get; set; }

    }
}