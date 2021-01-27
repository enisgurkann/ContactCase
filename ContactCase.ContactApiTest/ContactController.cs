using System;
using System.Collections.Generic;
using Xunit;

namespace ContactCase.ContactApiTest
{
    public class ContactController
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
        public class ContactInfo
        {
            public Guid Id { get; set; }
            public Guid ContactId { get; set; }
            public string InfoType { get; set; }
            public string Value { get; set; }

        }
        [Fact]
        public void CreateContact()
        {
            var model = new Contact {
                FirstName = "ens",
                LastName = "grkn",
                CompanyName = "test",
                Infos = new List<ContactInfo>
                {
                    new ContactInfo(){ InfoType = "phone", Value = "05071436243" },
                    new ContactInfo(){ InfoType = "email", Value = "enisgurkan01@gmail.com" },
                }
            };

            Assert.NotEqual(Guid.Empty, model.Id);
            Assert.NotEqual(DateTime.MinValue, model.CreateDate);
        }
    }
}
