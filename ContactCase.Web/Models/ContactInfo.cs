using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCase.Web.Models
{
    public class ContactInfo
    {
        public Guid Id { get; set; }
        public Guid ContactId { get; set; }
        public string Value { get; set; }
        public string InfoType { get; set; }
    }
}
