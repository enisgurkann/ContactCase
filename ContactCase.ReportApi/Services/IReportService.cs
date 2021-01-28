using ContactCase.ReportApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCase.ReportApi.Services
{
    interface IReportService
    {
        Task<List<Report>> GetAll(int pageIndex, int pageSize);
        Task<bool> Add(Report model);
        Task<Report> GetById(Guid Id);
    }
}
