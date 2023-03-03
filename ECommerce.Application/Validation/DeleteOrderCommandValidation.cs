using ECommerce.Application.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Validation
{
    public class DeleteOrderCommandValidation : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidation()
        {
            RuleFor(o => o.Id)
                   .NotEmpty().WithMessage("Shopper Id is required")
                   .NotNull().WithMessage("Shopper Id cannot be null");
        }
    }
}
