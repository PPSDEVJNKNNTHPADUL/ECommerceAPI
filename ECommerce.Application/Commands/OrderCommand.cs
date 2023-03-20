using ECommerce.Domain.Models;
using MediatR;

namespace ECommerce.Application.Commands
{
    public class OrderCommand
    {
        // Defines a class for deleting an order, with an ID.
        // The command doesn't return anything (i.e., the return type is `void`).
        public class DeleteOrderCommand : IRequest
        {
            // The ID of the order to be deleted.
            public Guid Id { get; set; }
        }

        // Defines a class for updating an order, with an ID and an OrderModel object.
        // The command returns an OrderModel object.
        public class UpdateOrderCommand : IRequest<OrderModel>
        {
            // The ID of the order to be updated.
            public Guid OrderId { get; set; }

            // The updated OrderModel object.
            public OrderModel Order { get; set; }
        }
    }
}
