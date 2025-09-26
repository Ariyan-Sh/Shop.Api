using Common.Application.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Roles.Edit
{
    public class EditRoleCommandValidator:AbstractValidator<EditRoleCommand>
    {
        public EditRoleCommandValidator()
        {
            RuleFor(r => r.title).NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
        }
    }
}
