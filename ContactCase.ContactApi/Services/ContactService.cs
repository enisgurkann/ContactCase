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
     

        public async Task<Contact> GetById(Guid Id)
        {
            var model = await _datacontext.Contacts.FirstOrDefaultAsync(s => s.Id == Id);
            model.Infos = await _datacontext.ContactInfos.Where(s => s.ContactId == model.Id).ToListAsync();
            return model;
        }

        public async Task<bool> Remove(Guid Id)
        {
            var model = await GetById(Id);
            _datacontext.Contacts.Remove(model);
            return await _datacontext.SaveChangesAsync() > 0;
        }

        public async Task<List<Contact>> GetAll(int pageIndex, int pageSize)
        {
            List<Contact> lists = await _datacontext.Contacts.Skip(pageIndex).Take(pageSize).ToListAsync();
            return lists;
        }

        public async Task<bool> Update(Contact model)
        {
            _datacontext.Contacts.Update(model);
            return await _datacontext.SaveChangesAsync() > 0;
        }
    }
}
