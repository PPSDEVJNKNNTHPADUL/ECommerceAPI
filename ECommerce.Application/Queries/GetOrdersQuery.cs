using ECommerce.Domain.Models;
using MediatR;

namespace ECommerce.Application.Queries
{
    public class GetOrdersQuery : IRequest<List<OrderModel>>
    {
    }

}
