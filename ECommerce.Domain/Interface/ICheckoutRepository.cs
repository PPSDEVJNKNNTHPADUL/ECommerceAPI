using ECommerce.Domain.Models;
using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Interface
{
    
    public interface ICheckoutRepository
    {
        
        Task<Guid> CheckoutOrderEntity(CheckoutEntity checkout);
       
    }
}
