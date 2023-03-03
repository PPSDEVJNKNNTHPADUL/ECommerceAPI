using ECommerce.Application.Commands;
using ECommerce.Application.Queries;
using ECommerce.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserDTO addUserDTO)
        {
            var command = new AddUserCommand
            {
                UserName = addUserDTO.UserName
            };
            var user = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetUserById), new { userId = user.UserId }, user);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            var query = new GetUserByIdQuery
            {
                UserId = userId
            };
            var user = await _mediator.Send(query);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
