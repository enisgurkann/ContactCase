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
        public ContactController(IContactService contactService)
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

            var stat = await _contactService.Add(createContact);
            return Ok(stat);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] Contact model)
        {
            if (model is null)
                return BadRequest();

            var contactModel = await _contactService.Update(model);
            return Ok(contactModel);
        }

        [HttpDelete("{id:Guid?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _contactService.Remove(id);
            return NoContent();
        }

        [HttpGet("{id:Guid?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] Guid? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var model = await _contactService.GetById(id.Value);
            if (model == null)
                return NotFound("Not found.");

            return Ok(model);
        }
    }
}
