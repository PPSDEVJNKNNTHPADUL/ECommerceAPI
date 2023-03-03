using ECommerce.Domain.Models;
using MediatR;

namespace ECommerce.Application.Queries
{
    public record GetAllCartItemsQuery() : IRequest<List<CartItemModel>>;
}