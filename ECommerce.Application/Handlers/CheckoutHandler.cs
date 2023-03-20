using ECommerce.Application.Commands;
using ECommerce.Domain.Interface;
using AutoMapper;
using MediatR;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Handlers
{
    public class CheckoutHandler
    {
        public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutCommand.CheckoutOrderCommand>
        {
            private readonly ICheckoutRepository _checkoutRepository;
            private readonly IMapper _mapper;

            public CheckoutOrderCommandHandler(ICheckoutRepository checkoutRepository, IMapper mapper)
            {
                _checkoutRepository = checkoutRepository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(CheckoutCommand.CheckoutOrderCommand request, CancellationToken cancellationToken)
            {
                var checkoutEntity = _mapper.Map<CheckoutEntity>(request.Checkout);
                await _checkoutRepository.CheckoutOrderEntity(checkoutEntity);
                return Unit.Value;
            }
        }
    }
}
