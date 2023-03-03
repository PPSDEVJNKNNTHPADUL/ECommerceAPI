using MediatR;

namespace ECommerce.Application.Commands
{
    public class DeleteOrderCommand : IRequest
    {
        public Guid Id { get; set; }
    }

}
