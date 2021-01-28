using ContactCase.Web.ApiClients;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCase.Web.Controllers
{
    public class ReportController : Controller
    {
        private readonly ReportApiClient _reportApiClient;

        public ReportController(ReportApiClient reportApiClient)
        {
            _reportApiClient = reportApiClient;
        }
        public async Task<IActionResult> Index([FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 20)
        {
            var model = await _reportApiClient.GetContacts(pageIndex, pageSize);
            model.NewReport = new ReportViewModel();
            PrepareCommonModel(model.NewReport);

            return View(model);
        }
    }
}
