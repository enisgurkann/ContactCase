using ContactCase.ReportApi.Data;
using ContactCase.ReportApi.Domain;
using ContactCase.ReportApi.Services;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCase.ReportApi.Consumer
{
    public class ReportConsumer
    {
        private readonly AppDBContext _datacontext;
        public ReportConsumer(AppDBContext context) => _datacontext = context;

        private readonly RabbitMQService _rabbitMQService;

      
        public async Task<bool> GenerateAsync(Guid id, string Tag, int Count)
        {
            var report = await _datacontext.Report.FirstOrDefaultAsync(x => x.Id == id);
            if (report is null)
                return false;

            report.Count = Count;
            report.Status = true;

            _datacontext.Report.Update(report);
            await _datacontext.SaveChangesAsync();
            return true;
        }

    }
}
