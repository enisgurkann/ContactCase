using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCase.ContactApi.Domain
{
    public class ContactInfo 
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int InfoTypeId { get; set; }

        public string InfoType { get; set; }
        public Guid ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
