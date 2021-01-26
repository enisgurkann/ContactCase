using ContactCase.ContactApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCase.ContactApi.Services
{
    interface IContactService
    {
        Task<IEnumerable<ContactInfo>> GetAll(int pageIndex, int pageSize);
        Task<bool> Add(ContactInfo model);
        Task<bool> Remove(int Id);
        Task<Contact> GetById(int Id);
    }
}
