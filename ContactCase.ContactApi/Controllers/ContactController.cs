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
    [Route("api/v{version:apiVersion}/contacts")]
    public class ContactController : ControllerBase
    {
        IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
      
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 20)
        {
            var contacts = await _contactService.GetAll(pageIndex,pageSize);
            return Ok(contacts);
        }

        [HttpGet("{id:Guid?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] Guid? id)
        {
            if (!id.HasValue || id.Value == Guid.Empty)
                return BadRequest();

            var contact = await _mediator.Send(new GetContactByIdQuery(id.Value));
            if (contact == null)
                return NotFound("Contact not found.");

            return Ok(contact);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] CreateContactCommand createContact)
        {
            if (createContact is null)
                return BadRequest();

            var contactModel = await _mediator.Send(createContact);
            return Ok(contactModel);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] UpdateContactCommand updateContact)
        {
            if (updateContact is null)
                return BadRequest();

            var contactModel = await _mediator.Send(updateContact);
            return Ok(contactModel);
        }

        [HttpDelete("{id:Guid?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] Guid? id)
        {
            if (!id.HasValue || id.Value == Guid.Empty)
                return BadRequest();

            await _mediator.Send(new DeleteContactCommand(id.Value));
            return NoContent();
        }

    }
}
