using ECommerce.Domain.Enumeration;

namespace ECommerce.Application.DTOs
{
    // Defines a data transfer object (DTO) for updating an order.
    public class UpdateOrderDTO
    {
        // The new status of the order.
        public OrderStatus orderStatus { get; set; }
    }
}
