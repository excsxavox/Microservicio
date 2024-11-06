using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserService.App.Queries.UserQueries;
using UserService.Interface;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Funcion para obtener los items completados
        [HttpGet("completed-items")]
        public async Task<ActionResult<List<user>>> GetUserCompletedItems()
        {

            var query = new GetUserItemsCompleted();

            var CompleteUser = await _mediator.Send(query);
            return Ok(CompleteUser);

        }
    }
}