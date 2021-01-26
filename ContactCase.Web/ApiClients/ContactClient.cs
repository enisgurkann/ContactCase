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

        public Task<ContactListViewModel> GetContacts(int pageIndex, int pageSize)
        {
            var response = _httpClient.GetFromJsonAsync<ContactListViewModel>($"api/contacts?pageIndex={pageIndex}&pageSize={pageSize}");
            return response;
        }

        public async Task<ContactViewModel> GetById(Guid id)
        {
            var response = await _httpClient.GetAsync($"api/v1/contacts/{id}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<ContactViewModel>();

            return null;
        }

        public async Task<ContactViewModel> Create(ContactViewModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("api/v1/contacts", model);
            return await response.Content.ReadFromJsonAsync<ContactViewModel>();
        }

        public async Task<ContactViewModel> Updatet(ContactViewModel model)
        {
            var response = await _httpClient.PutAsJsonAsync("api/v1/contacts", model);
            return await response.Content.ReadFromJsonAsync<ContactViewModel>();
        }

        public async Task<bool> Delete(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/v1/contacts/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
