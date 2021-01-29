using ContactCase.ReportApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContactCase.ReportApi.Services
{
    public class ReportMQService : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ReportMQService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
            InitRabbitMQ();
        }

        private void InitRabbitMQ()
        {

            var factory = new ConnectionFactory {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
            };

            // create connection  
            _connection = factory.CreateConnection();

            // create channel  
            _channel = _connection.CreateModel();

            var QueueName = "RAPOROLUSTUR";
            var exchangeName = "RAPOROLUSTUR-Exchange";
            _channel.ExchangeDeclare(exchangeName, ExchangeType.Topic, true);
            _channel.QueueDeclare(QueueName, false, false, false, null);
            _channel.QueueBind(QueueName, exchangeName, "");

            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (ch, ea) => {
                // received message  
                var content = System.Text.Encoding.UTF8.GetString(ea.Body.ToArray());

                // handle the received message  

                if (content.Contains("RAPOROLUSTURULDU")) {
                    Guid UUID = Guid.Parse(content.Split('$')[1]);
                    int COUNT = int.Parse(content.Split('$')[2]);
                    await GenerateAsync(UUID, COUNT);
                }

                _channel.BasicAck(ea.DeliveryTag, false);
            };

            consumer.Shutdown += OnConsumerShutdown;
            consumer.Registered += OnConsumerRegistered;
            consumer.Unregistered += OnConsumerUnregistered;
            consumer.ConsumerCancelled += OnConsumerConsumerCancelled;

            return Task.CompletedTask;
        }

        public async Task GenerateAsync(Guid id, int Count)
        {
            using (var scope = _serviceScopeFactory.CreateScope()) {
                var dataContext = scope.ServiceProvider.GetService<AppDBContext>();
                var report = await dataContext.Report.FirstOrDefaultAsync(x => x.Id == id);
                if (report is not null) {
                    report.Count = Count;
                    report.Status = true;
                    dataContext.Report.Update(report);
                    await dataContext.SaveChangesAsync();
                }
            }
        }

        private void OnConsumerConsumerCancelled(object sender, ConsumerEventArgs e) { }
        private void OnConsumerUnregistered(object sender, ConsumerEventArgs e) { }
        private void OnConsumerRegistered(object sender, ConsumerEventArgs e) { }
        private void OnConsumerShutdown(object sender, ShutdownEventArgs e) { }
        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e) { }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}
