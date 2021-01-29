using ContactCase.ReportApi.Data;
using ContactCase.ReportApi.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCase.ReportApi.Services
{
    public class ReportService : IReportService
    {
        private readonly AppDBContext _datacontext;
        public ReportService(AppDBContext context) => _datacontext = context;

        public async Task<Report> Add(string Tag)
        {
            var report = new Report();
            report.Tag = Tag;
            report.CreateDate = DateTime.Now;
            report.Status = false;
            await _datacontext.Report.AddAsync(report);
            await _datacontext.SaveChangesAsync();
            return report;
        }


    

        public async Task<List<Report>> GetAll(int pageIndex, int pageSize)
        {
            List<Report> lists = await _datacontext.Report.Skip(pageIndex).Take(pageSize).ToListAsync();
            return lists;
        }

        public async Task<Report> GetById(Guid Id)
        {
            var model = await _datacontext.Report.FirstOrDefaultAsync(s => s.Id == Id);
            return model;
        }
    }
}
