﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TecoBerBP.DataClasses.Enum;

namespace TecoBerBP.DataClasses
{
    public class BPUser
    {
        [Key]
        public int UserId { get; set; }

        [DisplayName("NET user Id")]
        public string NetUserId { get; set; }

        [DisplayName("Förnamn")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Efternamn")]
        [Required]
        public string SurName { get; set; }

        [DisplayName("Kön")]
        [EnumDataType(typeof(Gender))]
        public Gender? Gender { get; set; }

        [DisplayName("e-mail")]        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Alternativ e-mail")]
        [DataType(DataType.EmailAddress)]
        public string AltEmail { get; set; }

        [DisplayName("Titel")]
        public string Titel { get; set; }

        [DisplayName("Verksamhetsområde")]
        public string AreaOfExpertise { get; set; }

        [DisplayName("Mobil")]
        [DataType(DataType.PhoneNumber)]
        public string Cell { get; set; }

        [DisplayName("Företag")]
        public string Company { get; set; }

        [DisplayName("Organisationsnummer")]
        public string CompanyNo { get; set; }

        [DisplayName("Adress")]
        public string CompanyAddress { get; set; }

        [DisplayName("Postnummer")]
        public string CompanyZip { get; set; }

        [DisplayName("Stad")]
        public string CompanyCity { get; set; }

        [DisplayName("Affärsledare")]
        public string CompanyLead { get; set; }

        [DisplayName("Kontorets placering")]
        public string OfficeLocation { get; set; }

        [DisplayName("Födelsedatum")]
        public string DateOfBirth { get; set; }

        [DisplayName("Startdatum")]
        public string JoinedDate { get; set; }

        [DisplayName("Slutdatum")]
        public string QuitDate { get; set; }        

        [DisplayName("Kommentar")]
        public string Comment { get; set; }

        [DisplayName("Status")]
        [EnumDataType(typeof(Status))]
        public Status? Status { get; set; }

        //[DisplayName("Rättighetsnivå")]
        //public int RoleId { get; set; }

        public ICollection<BPActivity> BPActivites { get; set; }

        [DisplayName("Rättighetsnivå")]
        [EnumDataType(typeof(AuthenticationLevel))]
        public AuthenticationLevel? RoleId { get; set; }

    }
}
