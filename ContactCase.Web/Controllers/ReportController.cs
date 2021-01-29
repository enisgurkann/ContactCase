using ContactCase.Web.ApiClients;
using ContactCase.Web.Models;
using Microsoft.AspNetCore.Mvc;
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
            var model = await _reportApiClient.GetReports(pageIndex, pageSize);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string Tag)
        {
            ReportModel model = new ReportModel();
            model.Tag = Tag;

            if (ModelState.IsValid) {
                var createResult = await _reportApiClient.CreateReport(Tag);
                if (createResult is not null) {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }
    }
}
