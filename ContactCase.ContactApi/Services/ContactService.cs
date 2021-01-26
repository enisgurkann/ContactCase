using ContactCase.ContactApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCase.ContactApi.Services
{
    public class ContactService : IContactService
    {
        public Task<bool> Add { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Task<bool> Remove { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Task<Contact> GetById { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
