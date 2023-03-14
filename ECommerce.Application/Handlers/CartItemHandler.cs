using AutoMapper;
using ECommerce.Application.Commands;
using ECommerce.Application.Queries;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interface;
using ECommerce.Domain.Models;
using MediatR;

namespace ECommerce.Application.Handlers
{
    public class CartItemHandler
    {
        public class AddCartItemCommandHandler : IRequestHandler<CartItemCommand.AddCartItemCommand, CartItemModel>
        {
            private readonly ICartItemRepository _cartItemRepository;
            private readonly IMapper _mapper;

            public AddCartItemCommandHandler(ICartItemRepository cartItemRepository, IMapper mapper)
            {
                _cartItemRepository = cartItemRepository;
                _mapper = mapper;
            }

            public async Task<CartItemModel> Handle(CartItemCommand.AddCartItemCommand request, CancellationToken cancellationToken)
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

        public class DeleteCartItemCommandHandler : IRequestHandler<CartItemCommand.DeleteCartItemCommand>
        {
            private readonly ICartItemRepository _cartItemRepository;

            public DeleteCartItemCommandHandler(ICartItemRepository cartItemRepository)
            {
                _cartItemRepository = cartItemRepository;
            }

            public async Task<Unit> Handle(CartItemCommand.DeleteCartItemCommand request, CancellationToken cancellationToken)
            {
                await _cartItemRepository.DeleteCartItem(request.CartItemId);
                return Unit.Value;
            }
        }

        public class GetAllCartItemQueryHandler : IRequestHandler<CartItemQuery.GetAllCartItemsQuery, List<CartItemModel>>
        {
            private readonly ICartItemRepository _cartRepository;

            public GetAllCartItemQueryHandler(ICartItemRepository cartRepository)
            {
                _cartRepository = cartRepository;
            }

            public async Task<List<CartItemModel>> Handle(CartItemQuery.GetAllCartItemsQuery request, CancellationToken cancellationToken)
            {
                return await _cartRepository.GetAllCartItems(request.ShopperId);
            }
        }


        public class UpdateCartItemCommandHandler : IRequestHandler<CartItemCommand.UpdateCartItemCommand, CartItemModel>
        {
            private readonly ICartItemRepository _repository;
            private readonly IMapper _mapper;

            public UpdateCartItemCommandHandler(ICartItemRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CartItemModel> Handle(CartItemCommand.UpdateCartItemCommand request, CancellationToken cancellationToken)
            {
                var cartItem = _mapper.Map<CartItemModel>(request);

                var updatedCartItem = await _repository.UpdateCartItem(cartItem);

                return updatedCartItem;
            }
        }
    }
}
