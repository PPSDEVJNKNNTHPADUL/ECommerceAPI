using ECommerce.Domain.Models;

namespace ECommerce.Domain.Interface
{
    public interface IOrderRepository
    {
        Task<List<OrderModel>> GetOrders(Guid userprimaryId);
        Task<OrderModel> GetOrderById(Guid id);
        Task<OrderModel> UpdateOrder(OrderModel orders);
        Task DeleteOrderById(Guid id);
    }
}
