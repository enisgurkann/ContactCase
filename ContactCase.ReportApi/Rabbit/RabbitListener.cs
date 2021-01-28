using ContactCase.ReportApi.Data;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCase.ReportApi.Rabbit
{
    public class RabbitListener
    {
        public RabbitListener(AppDBContext context)
        {
            this.factory = new ConnectionFactory() { HostName = "localhost" };
            this.connection = factory.CreateConnection();
            this.channel = connection.CreateModel();
            this._datacontext = context;
        }

        ConnectionFactory factory { get; set; }
        IConnection connection { get; set; }
        RabbitMQ.Client.IModel channel { get; set; }
        AppDBContext _datacontext { get; set; }

        public async Task<bool> GenerateAsync(string id, string Tag,int Count)
        {
            var report = await _datacontext.Report.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            if (report is null)
                return false;

            report.Count = Count;
            report.Status = true;

            _datacontext.Report.Update(report);
            await _datacontext.SaveChangesAsync();
            return true;
        }


        public void Register()
        {
            channel.QueueDeclare(queue: "report", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                string data = Encoding.UTF8.GetString(body);
                await GenerateAsync(data.Split('-')[0].ToString(), data.Split('-')[1].ToString(), 0);
            };
            channel.BasicConsume(queue: "report", autoAck: true, consumer: consumer);
        }

        public void Deregister()
        {
            this.connection.Close();
        }

       
    }
}
