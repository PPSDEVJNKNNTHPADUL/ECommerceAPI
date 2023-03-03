using ECommerce.Domain.Enumeration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Domain.Entities
{
    public class CheckoutEntity
    {
        [Key]
        public Guid CheckoutId { get; set; }

        [ForeignKey(nameof(OrderEntity))]
        public Guid OrderPrimaryId { get; set; }
        public OrderEntity? OrderEntity { get; set; }

        public OrderStatus OrderStatus { get; set; }
    }
}
