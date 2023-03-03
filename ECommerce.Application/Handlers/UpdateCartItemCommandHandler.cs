using AutoMapper;
using ECommerce.Application.Commands;
using ECommerce.Domain.Interface;
using ECommerce.Domain.Models;
using MediatR;

namespace ECommerce.Application.Handlers
{
    public class UpdateCartItemCommandHandler : IRequestHandler<UpdateCartItemCommand, CartItemModel>
    {
        private readonly ICartItemRepository _repository;
        private readonly IMapper _mapper;

        public UpdateCartItemCommandHandler(ICartItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CartItemModel> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
        {
            var cartItem = _mapper.Map<CartItemModel>(request);

            var updatedCartItem = await _repository.UpdateCartItem(cartItem);

            return updatedCartItem;
        }
    }
}
