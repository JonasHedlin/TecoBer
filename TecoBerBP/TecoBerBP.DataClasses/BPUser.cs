using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecoBerBP.DataClasses
{
    public class BPUser
    {
        public virtual int Id { get; set; }
        public virtual string NetUserId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string AltEmail { get; set; }
        public virtual string Titel { get; set; }
        public virtual string AreaOfExpertise { get; set; }
        public virtual string Cell { get; set; }
        public virtual string Company { get; set; }
        public virtual string CompanyNo { get; set; }
        public virtual string CompanyAddress { get; set; }
        public virtual string CompanyZip { get; set; }
        public virtual string CompanyCity { get; set; }
        public virtual string OfficeLocation { get; set; }
        public virtual string CompanyLead { get; set; }
    }
}
