using ECommerce.Domain.Entities;
using ECommerce.Domain.Enumeration;
using ECommerce.Domain.Interface;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerce.Infrastructure.Repository
{
    public class CheckoutRepository : ICheckoutRepository
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<CheckoutRepository> _logger;

        public CheckoutRepository(DataContext dataContext, ILogger<CheckoutRepository> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public async Task<Guid> CheckoutOrderEntity(CheckoutEntity checkoutEntity)
        {
            _logger.LogInformation("Order Status has been updated");

            try
            {
                var order = await _dataContext.Orders
                    .FirstOrDefaultAsync(o => o.OrderId == checkoutEntity.OrderPrimaryId && o.OrderStatus == OrderStatus.Pending);

                if (order != null)
                {
                    order.OrderStatus = checkoutEntity.OrderStatus == OrderStatus.Processed ? OrderStatus.Processed : OrderStatus.Cancelled;
                    _dataContext.Orders.Update(order);

                    _dataContext.Checkouts.Add(checkoutEntity);

                    await _dataContext.SaveChangesAsync();
                    _logger.LogInformation("Status update success..");

                    return checkoutEntity.CheckoutId;
                }
                else
                {
                    _logger.LogWarning("No pending order found for OrderPrimaryId: {id}", checkoutEntity.OrderPrimaryId);
                    return Guid.Empty;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in Retrieving Checkout Details:{ex}", ex);
                throw;
            }
        }
    }
}
