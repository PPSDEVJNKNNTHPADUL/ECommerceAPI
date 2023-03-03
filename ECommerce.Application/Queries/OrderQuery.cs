using ECommerce.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Queries
{
    public class OrderQuery
    {
        public class GetOrderByIdQuery : IRequest<OrderModel>
        {
            public Guid Id { get; set; }
        }
        public class GetOrdersQuery : IRequest<List<OrderModel>>
        {
        }
    }
}
