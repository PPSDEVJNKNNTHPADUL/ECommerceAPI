using AutoMapper;
using Dapper;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interface;
using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerce.Infrastructure.Repository
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly ILogger<CartItemRepository> _logger;

        public CartItemRepository(DataContext dataContext, IMapper mapper, ILogger<CartItemRepository> logger)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CartItemModel> AddCartItem(CartItemModel newCartItem)
        {
            try
            {
                _logger.LogInformation("Add Cart Item");

                var shopper = await _dataContext.Users.SingleOrDefaultAsync(u => u.UserId == newCartItem.ShopperId);
                var shopperOrder = await _dataContext.Orders.SingleOrDefaultAsync(u => u.UserPrimaryId == newCartItem.ShopperId && u.OrderStatus == 0);
                var cartItemEntity = _mapper.Map<CartItemEntity>(newCartItem);

                if (shopperOrder != null)
                {
                    cartItemEntity.OrderPrimaryId = shopperOrder.OrderId;
                    shopperOrder.CartItems.Add(cartItemEntity);
                    _dataContext.Orders.Update(shopperOrder);
                }
                else
                {
                    _logger.LogInformation("Create new Order");
                    var orderEntity = new OrderEntity()
                    {
                        UserPrimaryId = shopper.UserId,
                        OrderStatus = 0,
                        CartItems = new List<CartItemEntity>() {
                  cartItemEntity
                }
                    };
                    _dataContext.Orders.Add(orderEntity);
                }

                await _dataContext.SaveChangesAsync();

                return _mapper.Map<CartItemModel>(cartItemEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in creating cart item details: {ex}", ex);
                throw;
            }
        }

        public async Task DeleteCartItem(Guid cartItemId)
        {
            _logger.LogInformation("Delete Cart Item by Id");
            try
            {
                var cartItemEntity = await _dataContext.CartItems.FindAsync(cartItemId);

                if (cartItemEntity != null)
                {
                    _dataContext.CartItems.Remove(cartItemEntity);
                    await _dataContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in deleting cart item details: {ex}",ex);
                throw;
            }
        }

        public async Task<List<CartItemModel>> GetAllCartItems()
        {
            _logger.LogInformation("Get All Cart Items executing..");
            try
            {
                var query = @"
            SELECT ci.*
            FROM CartItems ci
            INNER JOIN Orders o 
            ON ci.OrderPrimaryId = o.OrderId
            WHERE o.OrderStatus = @orderStatus";

                var con = _dataContext.Database.GetDbConnection();
                var cartItems = await con.QueryAsync<CartItemModel>(query, new
                {
                    orderStatus = 0
                });

                return cartItems.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in getting all cart item details: {ex}", ex);
                throw;
            }
        }

        public async Task<CartItemModel> UpdateCartItem(CartItemModel cartItem)
        {
            try
            {
                var existingCartItem = await _dataContext.CartItems.FirstOrDefaultAsync(ci => ci.CartItemId == cartItem.CartItemId);

                if (existingCartItem == null)
                {
                    throw new Exception($"Cart item with ID {cartItem.CartItemId} not found");
                }
                existingCartItem.ProductName = cartItem.ProductName;

                await _dataContext.SaveChangesAsync();

                var updatedCartItem = _mapper.Map<CartItemModel>(existingCartItem);
                return updatedCartItem;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error updating cart item with ID {cartItem.CartItemId}: {ex}", ex);
                throw;
            }
        }
    }

}
