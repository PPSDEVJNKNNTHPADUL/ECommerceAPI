using ECommerce.Application.Commands;
using ECommerce.Domain.Interface;
using MediatR;

namespace ECommerce.Application.Handlers
{
    public class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommand>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public DeleteCartItemCommandHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<Unit> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            await _cartItemRepository.DeleteCartItem(request.CartItemId);
            return Unit.Value;
        }
    }
}
