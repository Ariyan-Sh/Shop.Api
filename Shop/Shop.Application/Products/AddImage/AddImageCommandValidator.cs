using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.AddImage
{
    public class AddImageCommandValidator:AbstractValidator<AddProductImageCommand>
    {
        public AddImageCommandValidator()
        {
            RuleFor(f => f.ImageFile)
                .NotEmpty().WithMessage(ValidationMessages.required("عکس"))
                .JustImageFile();

            RuleFor(f => f.Sequence).GreaterThanOrEqualTo(0);
        }
    }
}
