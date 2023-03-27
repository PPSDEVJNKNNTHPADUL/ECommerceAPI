﻿using ECommerce.Domain.Models;
using MediatR;

namespace ECommerce.Application.Commands
{
    public class OrderCommand
    {

        public class DeleteOrderCommand : IRequest
        {

            public Guid Id { get; set; }
        }

        public class UpdateOrderCommand : IRequest<OrderModel>
        {

            public Guid OrderId { get; set; }


            public OrderModel Order { get; set; }
        }
    }
}
