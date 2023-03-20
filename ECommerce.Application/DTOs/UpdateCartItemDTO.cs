namespace ECommerce.Application.DTOs
{
    // Defines a data transfer object (DTO) for updating a cart item.
    public class UpdateCartItemDTO
    {
        // The new name of the product associated with the cart item.
        public string? ProductName { get; set; }
    }
}
