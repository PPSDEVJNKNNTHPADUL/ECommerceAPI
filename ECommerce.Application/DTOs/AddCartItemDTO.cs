namespace ECommerce.Application.DTOs
{
    public class AddCartItemDTO
    {
        public Guid ShopperId { get; set; }
        public string ProductName { get; set; } = string.Empty;
    }
}
