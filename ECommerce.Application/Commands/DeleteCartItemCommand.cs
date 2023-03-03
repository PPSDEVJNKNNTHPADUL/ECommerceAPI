using MediatR;

namespace ECommerce.Application.Commands
{
    public record DeleteCartItemCommand(Guid CartItemId) : IRequest;
}
