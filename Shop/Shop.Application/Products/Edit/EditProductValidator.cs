using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.Edit
{
    public class EditProductValidator:AbstractValidator<EditProductCommand>
    {
        public EditProductValidator()
        {
            RuleFor(r => r.Title).NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(r => r.Description).NotEmpty().WithMessage(ValidationMessages.required("توضیحات"));

            RuleFor(r => r.ImageFile).JustImageFile();

            RuleFor(r => r.Slug).NotEmpty().WithMessage(ValidationMessages.required("slug"));
        }
    }
}
