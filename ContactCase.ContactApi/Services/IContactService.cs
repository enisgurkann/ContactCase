using ContactCase.ContactApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCase.ContactApi.Services
{
    interface IContactService
    {
        Task<List<ContactInfo>> GetAll(int pageIndex, int pageSize);
        Task<bool> Add(ContactInfo model);
        Task<bool> Remove(Guid Id);
        Task<Contact> GetById(Guid Id);
    }
}
