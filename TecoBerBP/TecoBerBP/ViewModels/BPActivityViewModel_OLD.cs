using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TecoBerBP.ViewModels
{
    public class BPActivityViewModel
    {
        [Required]
        public int Id { get; set; }

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