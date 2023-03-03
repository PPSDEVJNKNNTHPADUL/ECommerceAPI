using ECommerce.Domain.Models;
using MediatR;

namespace ECommerce.Application.Commands
{
    public class UpdateCartItemCommand : IRequest<CartItemModel>
    {
        public Guid CartItemId { get; set; }
        public string ProductName { get; set; }
    }
}
