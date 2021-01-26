using ContactCase.ContactApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCase.ContactApi.Services
{
    interface IContactService
    {
        Task<bool> Add { get; set; }
        Task<bool> Remove { get; set; }
        Task<Contact> GetById { get; set; }
    }
}
