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

        public ContactController()
        {
        }

      
    }
}
