using ECommerce.Domain.Models;
using MediatR;

namespace ECommerce.Application.Commands
{
    public class UpdateOrderCommand : IRequest<OrderModel>
    {
        public Guid OrderId { get; set; }
        public OrderModel Order { get; set; }
    }

}
