using ECommerce.Application.Commands;
using ECommerce.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CheckoutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CheckoutOrder(CheckoutModel checkout)
        {
            var command = new CheckoutOrderCommand { Checkout = checkout };
            await _mediator.Send(command);
            return Ok();
        }
    }
}
