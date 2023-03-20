using ECommerce.Domain.Enumeration;

namespace ECommerce.Application.DTOs
{
    // Defines a data transfer object (DTO) for checkout information.
    public class CheckoutDTO
    {
        // The unique identifier of the order.
        public Guid OrderPrimaryId { get; set; }

        // The unique identifier of the shopper who placed the order.
        public Guid ShopperId { get; set; }

        // The status of the order.
        public OrderStatus OrderStatus { get; set; }
    }
}
