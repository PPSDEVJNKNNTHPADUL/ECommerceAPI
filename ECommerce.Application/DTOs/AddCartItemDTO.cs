using ECommerce.Domain.Enumeration;

namespace ECommerce.Application.DTOs
{
    // Defines a data transfer object (DTO) for adding a cart item.
    public class AddCartItemDTO
    {
        // The name of the product to be added to the cart.
        public string ProductName { get; set; }
    }
}
