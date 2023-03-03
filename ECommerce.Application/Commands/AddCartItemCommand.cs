using ECommerce.Domain.Models;
using MediatR;

namespace ECommerce.Application.Commands
{
    public record AddCartItemCommand(Guid ShopperId, string ProductName) : IRequest<CartItemModel>;
}
