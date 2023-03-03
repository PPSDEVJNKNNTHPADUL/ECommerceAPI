using ECommerce.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Queries
{
    public class UserQuery
    {
        public class GetUserByIdQuery : IRequest<UserModel>
        {
            public Guid UserId { get; set; }
        }
    }
}
