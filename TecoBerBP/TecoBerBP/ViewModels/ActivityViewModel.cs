using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
        public int DurationUnit { get; set; }
    }
}