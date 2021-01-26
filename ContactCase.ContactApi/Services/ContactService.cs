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
        private readonly AppDBContext _datacontext;
        public ContactService(AppDBContext context)
        {
            _datacontext = context;
        }

        public async Task<bool> Add(Contact model)
        {
            await _datacontext.Contacts.AddAsync(model);
            return await _datacontext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Contact>> GetAll(int pageIndex, int pageSize)
        {
            List<Contact> lists = await _datacontext.Contacts.Skip(pageIndex).Take(pageSize).ToListAsync();
            return (IEnumerable<Contact>)lists;
        }

        public Task<Contact> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(Guid Id)
        {
            throw new NotImplementedException();
        }

        Task<List<Contact>> IContactService.GetAll(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
