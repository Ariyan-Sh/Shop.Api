using Common.Application.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Comments.Edit
{
    public class EditCommentValidator:AbstractValidator<EditCommentCommand>
    {
        public EditCommentValidator()
        {
            RuleFor(r => r.text).NotNull().MinimumLength(5).WithMessage(ValidationMessages.maxLength("متن نظر", 5));
        }
    }
}
