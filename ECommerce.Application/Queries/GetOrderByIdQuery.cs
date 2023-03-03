using ECommerce.Domain.Models;
using MediatR;

namespace ECommerce.Application.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderModel>
    {
        public Guid Id { get; set; }
    }

}
