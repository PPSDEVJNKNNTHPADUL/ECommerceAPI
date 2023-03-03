using ECommerce.Application.Commands;
using ECommerce.Application.Queries;
using ECommerce.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            await _mediator.Send(new DeleteOrderCommand { Id = id });
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderModel>> GetOrder(Guid id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery { Id = id });
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderModel>>> GetOrders()
        {
            var orders = await _mediator.Send(new GetOrdersQuery());
            return orders;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, OrderModel order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }
            var updatedOrder = await _mediator.Send(new UpdateOrderCommand { Order = order });
            return Ok(updatedOrder);
        }
    }

}
