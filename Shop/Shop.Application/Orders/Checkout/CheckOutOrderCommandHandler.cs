using Common.Application;
using Shop.Domain.OrderAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.OrderAgg;

namespace Shop.Application.Orders.Checkout
{
    public class CheckOutOrderCommandHandler:IBaseCommandHandler<CheckOutOrderCommand>
    {
        private readonly IOrderRepository _repository;

        public CheckOutOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CheckOutOrderCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _repository.GetCurrentUserOrder(request.UserId);
            if(currentOrder == null)
            {
                return OperationResult.NotFound();
            }
            var address = new OrderAddress(request.Shire, request.City, request.PostalCode, request.PostalAddress, request.PhoneNumber, request.Name, request.Family, request.NationalCode);
            currentOrder.Checkout(address);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
