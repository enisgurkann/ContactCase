using ContactCase.ContactApi.Domain;
using ContactCase.ContactApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCase.ContactApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/contacts")]
    public class ContactController : ControllerBase
    {
        IContactService _contactService;
        public ContactController(ContactService contactService)
        {
            _contactService = contactService;
        }
      
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] int pageIndex = 0,[FromQuery] int pageSize = 20)
        {
            var contacts = await _contactService.GetAll(pageIndex,pageSize);
            return Ok(contacts);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] Contact createContact)
        {
            if (createContact is null)
                return BadRequest();

            var contacts = await _contactService.Add(createContact);
            return Ok(contacts);
        }

    }
}
