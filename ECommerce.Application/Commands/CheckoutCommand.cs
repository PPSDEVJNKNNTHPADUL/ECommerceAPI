using ECommerce.Domain.Models;
using MediatR;

namespace ECommerce.Application.Commands
{
    public class CheckoutCommand
    {
        // Defines a class for checking out an order, with a CheckoutModel object.
        // The command doesn't return anything (i.e., the return type is `void`).
        public class CheckoutOrderCommand : IRequest
        {
            // The CheckoutModel object that represents the order to be checked out.
            public CheckoutModel Checkout { get; set; }
        }
    }
}
