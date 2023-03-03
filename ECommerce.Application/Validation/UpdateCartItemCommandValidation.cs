using ECommerce.Application.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Validation
{
    public class UpdateCartItemCommandValidation : AbstractValidator<UpdateCartItemCommand>
    {
        public UpdateCartItemCommandValidation()
        {
            RuleFor(ci => ci.CartItemId)
                .NotEmpty().WithMessage("Shopper Id is required")
                .NotNull().WithMessage("Shopper Id cannot be null");

            RuleFor(ci => ci.ProductName)
                .NotEmpty().WithMessage("Shopper Id is required")
                .NotNull().WithMessage("Shopper Id cannot be null");
        }
    }
}
