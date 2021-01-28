using ContactCase.ReportApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCase.ReportApi.Services
{
    public class ReportService : IReportService
    {
        public Task<bool> Add(Report model)
        {
            throw new NotImplementedException();
        }

        public Task<List<Report>> GetAll(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<Report> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
