using AutoMapper;
using ECommerce.Application.Queries;
using ECommerce.Domain.Interface;
using ECommerce.Domain.Models;
using MediatR;

namespace ECommerce.Application.Handlers
{
    public class GetAllCartItemQueryHandler : IRequestHandler<GetAllCartItemsQuery, List<CartItemModel>>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public GetAllCartItemQueryHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<List<CartItemModel>> Handle(GetAllCartItemsQuery request, CancellationToken cancellationToken)
        {
            var result = await _cartItemRepository.GetAllCartItems();
            return result;
        }
    }
}
