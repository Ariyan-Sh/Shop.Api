using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders.Checkout
{
    public class CheckOutOrderCommandValidator:AbstractValidator<CheckOutOrderCommand>
    {
        public CheckOutOrderCommandValidator()
        {
            RuleFor(f => f.Name).NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام"));
            RuleFor(f => f.Family).NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام خانوادگی"));
            RuleFor(f => f.City).NotNull().NotEmpty().WithMessage(ValidationMessages.required("شهر"));
            RuleFor(f => f.Shire).NotNull().NotEmpty().WithMessage(ValidationMessages.required("استان"));

            RuleFor(f => f.PhoneNumber)
                .NotNull()
                .NotEmpty().
                WithMessage(ValidationMessages.required("شماره موبایل"))
                .MaximumLength(11).WithMessage("شماره موبایل نامعتبر است")
                .MinimumLength(11).WithMessage("شماره موبایل نامعتبر است");

            RuleFor(f => f.NationalCode)
                .NotNull()
                .NotEmpty().
                WithMessage(ValidationMessages.required("کد ملی"))
                .MaximumLength(10).WithMessage("کد ملی نامعتبر است")
                .MinimumLength(10).WithMessage("کد ملی نامعتبر است")
                .ValidNationalId();

            RuleFor(f => f.PostalAddress).NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام"));
            RuleFor(f => f.PostalAddress).NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام"));

        }
    }
}
