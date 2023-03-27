using ECommerce.Domain.Models;
using MediatR;

namespace ECommerce.Application.Commands
{
    public class CheckoutCommand
    {
        public class CheckoutOrderCommand : IRequest
        {
            public CheckoutModel Checkout { get; set; }
        }
    }
}
