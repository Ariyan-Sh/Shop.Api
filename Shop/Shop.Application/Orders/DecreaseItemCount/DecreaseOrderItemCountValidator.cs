using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders.DecreaseItemCount
{
    public class DecreaseOrderItemCountValidator:AbstractValidator<DecreaseOrderItemCountCommand>
    {
        public DecreaseOrderItemCountValidator()
        {
            RuleFor(f => f.Count).GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از 0 باشد");
        }
    }
}
