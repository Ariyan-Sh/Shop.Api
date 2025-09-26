using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SiteEntities.ShippingMethod.Create
{
    public class CreateShippingMethodCommandValidator:AbstractValidator<CreateShippingMethodCommand>
    {
        public CreateShippingMethodCommandValidator()
        {
            RuleFor(f => f.Title).NotNull().NotEmpty();
        }
    }
}
