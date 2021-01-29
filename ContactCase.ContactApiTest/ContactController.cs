using ContactCase.ContactApi.Data;
using ContactCase.ContactApi.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace ContactCase.ContactApiTest
{
    public class ContactController
    {
        protected AppDBContext CreateDbContext(string dbName = "ContactApi")
        {
            var context = new AppDBContext(new DbContextOptionsBuilder<AppDBContext>()
            .UseInMemoryDatabase(databaseName: dbName ?? Guid.NewGuid().ToString())
            .Options);

            return context;
        }
      
        [Fact]
        public void CreateContact()
        {
            var dbcontext = CreateDbContext();
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

            dbcontext.Contacts.Add(model);
            dbcontext.SaveChanges();

            Assert.NotEqual(Guid.Empty, model.Id);
        }
    }
}
