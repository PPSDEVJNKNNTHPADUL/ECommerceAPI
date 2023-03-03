using ECommerce.Domain.Models;

namespace ECommerce.Domain.Interface
{
    public interface ICheckoutRepository
    {
        Task<Guid> CheckoutOrderEntity(CheckoutModel checkout);
    }
}
