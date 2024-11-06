using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserService.App.Commands.ItemCommads;
using UserService.App.Queries.ItemQueries;
using UserService.Interface;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly IMediator _mediator;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("distribute")]
        public async Task<IActionResult> Distribute([FromBody] ItemsCommand command)
        {
            await _mediator.Send(command);
            return Ok("Items Distribuidos Correctamente");
        }

        [HttpGet("getItems")]
        public async Task<ActionResult<List<Item>>> GetItems()
        {
            var query = new ItemsQuery();
            var workItems = await _mediator.Send(query);
            return Ok(workItems);
        }
    }
}