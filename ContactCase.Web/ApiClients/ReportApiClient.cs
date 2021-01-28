using ContactCase.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ContactCase.Web.ApiClients
{
    public class ReportApiClient
    {
        private readonly HttpClient _httpClient;

        public ReportApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ReportModel>> GetContacts(int pageIndex, int pageSize)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ReportModel>>($"api/report?pageIndex={pageIndex}&pageSize={pageSize}");
            return response;
        }

        public Task<ReportModel> GetReportById(int id)
        {
            var response = _httpClient.GetFromJsonAsync<ReportModel>($"api/report/{id}");
            return response;
        }

        public async Task<ReportModel> CreateReport(ReportModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("api/report", model);
            return await response.Content.ReadFromJsonAsync<ReportModel>();
        }
    }
}
