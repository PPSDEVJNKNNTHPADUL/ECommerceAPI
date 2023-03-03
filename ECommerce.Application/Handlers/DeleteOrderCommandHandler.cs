using ECommerce.Application.Commands;
using ECommerce.Domain.Interface;
using MediatR;

namespace ECommerce.Application.Handlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _repository;

        public DeleteOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteOrderById(request.Id);
            return Unit.Value;
        }
    }
}
