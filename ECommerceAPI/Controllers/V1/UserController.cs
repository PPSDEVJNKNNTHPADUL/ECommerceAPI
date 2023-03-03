using ECommerce.Application.Commands;
using ECommerce.Application.Queries;
using ECommerce.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers.V1
{
    [ApiVersion("1.0")]
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddUser([FromBody] AddUserDTO addUserDTO)
        {
            var command = new UserCommand.AddUserCommand
            {
                UserName = addUserDTO.UserName
            };
            var user = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetUserById), new { userId = user.UserId }, user);
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            var query = new UserQuery.GetUserByIdQuery
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
