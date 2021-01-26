using ContactCase.ContactApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCase.ContactApi.Services
{
    public class ContactService : IContactService
    {
        public Task<bool> Add(ContactInfo model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContactInfo>> GetAll(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
