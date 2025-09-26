using Common.Application.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Comments.Create
{
    public class CreateCommentValidator:AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentValidator()
        {
            RuleFor(r=>r.text).NotNull().MinimumLength(5).WithMessage(ValidationMessages.maxLength("متن نظر",5));
        }
    }
}
