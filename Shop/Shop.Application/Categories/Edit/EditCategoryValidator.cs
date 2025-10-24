using Common.Application.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categories.Edit
{
    public class EditCategoryValidator:AbstractValidator<EditCategoryCommand>
    {
        public EditCategoryValidator()
        {
            RuleFor(r => r.Title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(r => r.Slug).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Slug"));

        }
    }
}
