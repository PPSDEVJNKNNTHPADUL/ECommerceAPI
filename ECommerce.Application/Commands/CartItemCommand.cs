﻿using ECommerce.Domain.Models;
using MediatR;

namespace ECommerce.Application.Commands
{
    public class CartItemCommand
    {
        public record AddCartItemCommand(Guid ShopperId, string ProductName) : IRequest<CartItemModel>;


        public record DeleteCartItemCommand(Guid CartItemId) : IRequest;

        public class UpdateCartItemCommand : IRequest<CartItemModel>
        {

            public Guid CartItemId { get; set; }


            public string ProductName { get; set; }
        }
    }
}
