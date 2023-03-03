using ECommerce.Domain.Models;

namespace ECommerce.Domain.Interface
{
    public interface ICartItemRepository
    {
        Task<CartItemModel> AddCartItem(CartItemModel newCartItem);
        Task<List<CartItemModel>> GetAllCartItems();
        Task<CartItemModel> UpdateCartItem(CartItemModel cartItem);
        Task DeleteCartItem(Guid CartItemId);
    }
}
