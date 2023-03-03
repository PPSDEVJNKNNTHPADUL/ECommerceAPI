using AutoMapper;
using ECommerce.Application.Commands;
using ECommerce.Domain.Exceptions;
using ECommerce.Domain.Interface;
using ECommerce.Domain.Models;
using MediatR;

namespace ECommerce.Application.Handlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, OrderModel>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderModel> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderById(request.OrderId);

            // Map the updated order data to the existing order entity
            order = _mapper.Map(request.Order, order);

            // Update the order in the repository
            await _orderRepository.UpdateOrder(order);

            // Map the updated order entity back to a DTO and return it
            return _mapper.Map<OrderModel>(order);
        }
    }
}
