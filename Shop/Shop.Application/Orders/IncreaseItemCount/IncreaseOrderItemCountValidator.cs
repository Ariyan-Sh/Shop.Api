using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders.IncreaseItemCount
{
    public class IncreaseOrderItemCountValidator:AbstractValidator<IncreaseOrderItemCountCommand>
    {
        public IncreaseOrderItemCountValidator()
        {
            RuleFor(f => f.Count).GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از 0 باشد");
        }
    }
}
