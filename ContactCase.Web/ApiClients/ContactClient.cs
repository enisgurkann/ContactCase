using ContactCase.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ContactCase.Web.ApiClients
{
    public class ContactClient
    {
        private readonly HttpClient _httpClient;

        public ContactClient(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<List<ContactModel>> GetContacts(int pageIndex, int pageSize)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ContactModel>>($"api/contacts?pageIndex={pageIndex}&pageSize={pageSize}");
            return response;
        }

        public async Task<ContactModel> GetById(Guid id)
        {
            var response = await _httpClient.GetAsync($"api/contacts/{id}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<ContactModel>();

            return null;
        }

        public async Task<bool> Create(ContactModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("api/contacts", model);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Update(ContactModel model)
        {
            var response = await _httpClient.PutAsJsonAsync("api/contacts", model);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/contacts/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
