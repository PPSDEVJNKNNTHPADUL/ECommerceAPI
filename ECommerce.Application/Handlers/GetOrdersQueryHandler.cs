using ECommerce.Application.Queries;
using ECommerce.Domain.Interface;
using ECommerce.Domain.Models;
using MediatR;

namespace ECommerce.Application.Handlers
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<OrderModel>>
    {
        private readonly IOrderRepository _repository;

        public GetOrdersQueryHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<OrderModel>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetOrders();
        }
    }
}
