using ECommerce.Application.Queries;
using ECommerce.Domain.Interface;
using ECommerce.Domain.Models;
using MediatR;

namespace ECommerce.Application.Handlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderModel>
    {
        private readonly IOrderRepository _repository;

        public GetOrderByIdQueryHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrderModel> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetOrderById(request.Id);
        }
    }
}
