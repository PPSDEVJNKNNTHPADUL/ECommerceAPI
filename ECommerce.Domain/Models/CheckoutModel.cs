using ECommerce.Domain.Enumeration;
using System.Text.Json.Serialization;

namespace ECommerce.Domain.Models
{
    public class CheckoutModel
    {
        public Guid OrderPrimaryId { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OrderStatus OrderStatus { get; set; }
    }
}
