using ContactCase.Web.ApiClients;
using ContactCase.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCase.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactClient _contactClient;

        public ContactController(ContactClient contactClient) => _contactClient = contactClient;
        public async Task<IActionResult> Index([FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 20) => View(await _contactClient.GetContacts(pageIndex, pageSize));

        public IActionResult Create() => View(new ContactModel());

        [HttpPost]
        public async Task<IActionResult> Create(ContactModel model)
        {
            var result = await _contactClient.Create(model);
            if (result) 
                return RedirectToAction("Index");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] Guid? id)
        {
            if (!id.HasValue || id.Value == Guid.Empty)
                return StatusCode(404);

            if (await _contactClient.Delete(id.Value))
                return Ok();

            return StatusCode(404);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (!id.HasValue) {
                StatusCode(404, "Not Found");
                return RedirectToAction("Index");
            }
            var model = await _contactClient.GetById(id.Value);
            if (model == null)
                StatusCode(404, "Not Found");
            else
                return View(model);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ContactModel model)
        {
            if (ModelState.IsValid) {
                var updateResult = await _contactClient.Update(model);
                if (updateResult) return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
