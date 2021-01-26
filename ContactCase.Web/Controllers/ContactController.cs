using ContactCase.Web.ApiClients;
using ContactCase.Web.Models;
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
            if (result is not null) 
                return RedirectToAction("Edit", new { id = result.Id });

            return View(model);
        }


    }
}
