using ContactCase.ReportApi.Domain;
using ContactCase.ReportApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (reportModel)
                return Ok(reportModel);
            else
                return NotFound("Error");
        }
    }
}
