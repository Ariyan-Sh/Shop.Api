using Common.Application.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Roles.Create
{
    public class CreateRoleCommmandValidator:AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommmandValidator()
        {
            RuleFor(r => r.title).NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
        }
    }
}
