using ECommerce.Application.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Validation
{
    public class DeleteCartItemCommandValidation : AbstractValidator<DeleteCartItemCommand>
    {
        public DeleteCartItemCommandValidation()
        {
            RuleFor(ci => ci.CartItemId)
                .NotEmpty().WithMessage("CartItemId is required")
                .NotNull().WithMessage("CartItemId cannot be null");
        }
    }
}
