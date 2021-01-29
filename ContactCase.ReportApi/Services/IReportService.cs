using ContactCase.ReportApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCase.ReportApi.Services
{
    public interface IReportService
    {
        Task<List<Report>> GetAll(int pageIndex, int pageSize);
        Task<Report> Add(string Tag);
        Task<Report> GetById(Guid Id);
    }
}
