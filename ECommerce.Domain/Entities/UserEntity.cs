using System.ComponentModel.DataAnnotations;

// Define the namespace and class for the entity
namespace ECommerce.Domain.Entities
{
    public class UserEntity
    {
        // Mark the property as the primary key using the [Key] attribute
        [Key]
        public Guid UserId { get; set; }

        // Define the UserName property as a nullable string using the "?" operator
        public string? UserName { get; set; }

        // Define a property that represents a list of orders for the user, initialized with an empty list
        public List<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
    }
}
