using AutoMapper;
using ECommerce.Application.Commands;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interface;
using ECommerce.Domain.Models;
using MediatR;

namespace ECommerce.Application.Handlers
{
    public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommand, CartItemModel>
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;

        public AddCartItemCommandHandler(ICartItemRepository cartItemRepository, IMapper mapper)
        {
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
        }

        public async Task<CartItemModel> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
        {
            var newCartItem = _mapper.Map<CartItemModel>(new CartItemEntity
            {
                ShopperId = request.ShopperId,
                ProductName = request.ProductName
            });

            var result = await _cartItemRepository.AddCartItem(newCartItem);
            return result;
        }
    }
}
