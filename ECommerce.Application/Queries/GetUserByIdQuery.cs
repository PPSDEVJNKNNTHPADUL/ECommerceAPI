using ECommerce.Domain.Models;
using MediatR;

namespace ECommerce.Application.Queries
{
    public class GetUserByIdQuery : IRequest<UserModel>
    {
        public Guid UserId { get; set; }
    }
}
