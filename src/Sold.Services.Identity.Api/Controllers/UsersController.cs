using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sold.Services.Identity.Application.Commands;
using System.Threading.Tasks;

namespace Sold.Services.Identity.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}