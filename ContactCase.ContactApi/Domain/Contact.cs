using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCase.ContactApi.Domain
{
    public class Contact 
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public DateTime CreateDate { get; set; }

        public List<ContactInfo> Infos { get; set; } = new List<ContactInfo>();
    }
}
