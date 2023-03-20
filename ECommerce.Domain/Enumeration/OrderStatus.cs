using System.Text.Json.Serialization;

namespace ECommerce.Domain.Enumeration
{

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderStatus
    {

        Pending,

        Processed,

        Cancelled

    }
}