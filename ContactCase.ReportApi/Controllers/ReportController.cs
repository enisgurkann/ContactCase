using ContactCase.ReportApi.Domain;
using ContactCase.ReportApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCase.ReportApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/report")]

    public class ReportController : ControllerBase
    {
        IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 20)
        {
            var reports = await _reportService.GetAll(pageIndex, pageSize);
            return Ok(reports);
        }

        [HttpGet("{id:int?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] Guid? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var report = await _reportService.GetById(id.Value);
            if (report == null)
                return NotFound("Report not found.");

            return Ok(report);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] string Tag)
        {
            var reportModel = await _reportService.Add(Tag);
            
            if (reportModel is not null) {

                var factory = new ConnectionFactory {
                    HostName = "localhost",
                    UserName = "guest",
                    Password = "guest",
                };

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel()) {

                    channel.ExchangeDeclare("demo.exchange", ExchangeType.Topic);
                    channel.QueueDeclare("demo.queue.log", false, false, false, null);
                    channel.QueueBind("demo.queue.log", "demo.exchange", "demo.queue.*", null);
                    channel.BasicQos(0, 1, false);

                    channel.QueueDeclare(queue: "ReportQuee",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var message =$"RAPOROLUSTUR${reportModel.Id}${Tag}";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "ReportQuee",
                                         basicProperties: null,
                                         body: body);
                }

                return Ok(reportModel);
            }
            else
                return NotFound("Error");
        }
    }
}
