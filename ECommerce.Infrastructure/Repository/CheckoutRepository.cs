using AutoMapper;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enumeration;
using ECommerce.Domain.Interface;
using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerce.Infrastructure.Repository
{
    public class CheckoutRepository : ICheckoutRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly ILogger<CheckoutRepository> _logger;

        public CheckoutRepository(DataContext dataContext, IMapper mapper, ILogger<CheckoutRepository> logger)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> CheckoutOrderEntity(CheckoutModel checkout)
        {
            _logger.LogInformation("Order Status has been updated");
            try
            {
                var check = _mapper.Map<CheckoutEntity>(checkout);
                var order = await _dataContext.Orders
                    .Include(o => o.UserEntity)
                    .FirstOrDefaultAsync(o => o.OrderId == check.OrderPrimaryId && o.OrderStatus == OrderStatus.Pending);

                if (order != null)
                {
                    order.OrderStatus = checkout.OrderStatus == OrderStatus.Processed ? OrderStatus.Processed : OrderStatus.Cancelled;
                    _dataContext.Orders.Update(order);

                    var checkoutorder = new CheckoutEntity()
                    {
                        OrderPrimaryId = check.OrderPrimaryId,
                        OrderStatus = checkout.OrderStatus == OrderStatus.Processed ? OrderStatus.Processed : OrderStatus.Cancelled
                    };
                    _dataContext.Checkouts.Add(checkoutorder);

                    await _dataContext.SaveChangesAsync();
                    _logger.LogInformation("Status update success..");

                    return checkoutorder.CheckoutId;
                }
                else
                {
                    _logger.LogWarning("No pending order found for OrderPrimaryId: {id}", check.OrderPrimaryId);
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
