using ECommerce.Application.Commands;
using ECommerce.Domain.Interface;
using MediatR;

namespace ECommerce.Application.Handlers
{
    public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand>
    {
        private readonly ICheckoutRepository _checkoutRepository;

        public CheckoutOrderCommandHandler(ICheckoutRepository checkoutRepository)
        {
            _checkoutRepository = checkoutRepository;
        }

        public async Task<Unit> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            await _checkoutRepository.CheckoutOrderEntity(request.Checkout);
            return Unit.Value;
        }
    }
}
