using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace TecoBerBP.ViewModels
{
    public class UserActivityViewModel
    {
        public int UserActivityId { get; set; }

        public int UserId { get; set; }

        [DisplayName("Namn")]
        public string Name { get; set; }

        [DisplayName("Datum")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DateForActivity { get; set; }

        [DisplayName("Beskrivning")]        
        public string Description { get; set; }

        [DisplayName("Affärsledare")]
        public string CompanyLead { get; set; }

        [DisplayName("Aktivitets-kategori")]
        public string Activity { get; set; }
        
    }
}