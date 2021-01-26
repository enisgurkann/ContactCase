using ContactCase.ContactApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCase.ContactApi.Services
{
    public interface IContactService
    {
        Task<List<Contact>> GetAll(int pageIndex, int pageSize);
        Task<bool> Add(Contact model);
        Task<bool> Remove(Guid Id);
        Task<Contact> GetById(Guid Id);
        Task<bool> Update(Contact model);
    }
}
