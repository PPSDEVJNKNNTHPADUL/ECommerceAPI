namespace ECommerce.Application.DTOs
{
    // Defines a data transfer object (DTO) for a cart item.
    public class CartItemDTO
    {
        // The unique identifier of the cart item.
        public Guid CartItemId { get; set; }

        // The name of the product associated with the cart item.
        public string? ProductName { get; set; }

        // The unique identifier of the shopper who added the cart item.
        public Guid ShopperId { get; set; }

        // The unique identifier of the order that the cart item belongs to.
        public Guid OrderPrimaryId { get; set; }
    }
}
