using ECommerce.Domain.Enumeration;
using System.Text.Json.Serialization;

namespace ECommerce.Domain.Models
{
    
    public class CheckoutModel
    {
        
        public Guid OrderPrimaryId { get; set; }
        
        public OrderStatus OrderStatus { get; set; }
        
    }
}
