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

        public Task<List<ContactModel>> GetContacts(int pageIndex, int pageSize)
        {
            var response = _httpClient.GetFromJsonAsync<List<ContactModel>>($"api/contacts?pageIndex={pageIndex}&pageSize={pageSize}");
            return response;
        }

        public async Task<ContactModel> GetById(Guid id)
        {
            var response = await _httpClient.GetAsync($"api/v1/contacts/{id}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<ContactModel>();

            return null;
        }

        public async Task<ContactModel> Create(ContactModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("api/v1/contacts", model);
            return await response.Content.ReadFromJsonAsync<ContactModel>();
        }

        public async Task<ContactModel> Updatet(ContactModel model)
        {
            var response = await _httpClient.PutAsJsonAsync("api/v1/contacts", model);
            return await response.Content.ReadFromJsonAsync<ContactModel>();
        }

        public async Task<bool> Delete(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/v1/contacts/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
