using ContactCase.ContactApi.Data;
using ContactCase.ContactApi.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCase.ContactApi.Services
{
    public class ContactService : IContactService
    {
        AppDBContext _datacontext;
        public ContactService(AppDBContext context)
        {
            _datacontext = context;
        }

        public Task<bool> Add(ContactInfo model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ContactInfo>> GetAll(int pageIndex, int pageSize)
        {
            List<Contact> lists = await _datacontext.Contacts.Skip(pageIndex).Take(pageSize).ToListAsync();
            return (IEnumerable<ContactInfo>)lists;
        }

        public Task<Contact> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(Guid Id)
        {
            throw new NotImplementedException();
        }

        Task<List<ContactInfo>> IContactService.GetAll(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
