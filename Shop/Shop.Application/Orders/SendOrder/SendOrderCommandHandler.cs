using Common.Application;
using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.OrderAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders.SendOrder
{
    internal class SendOrderCommandHandler : IBaseCommandHandler<SendOrderCommand>
    {
        private readonly IOrderRepository _repository;

        public SendOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(SendOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetTracking(request.OrderId);
            if (order == null)
            {
                return OperationResult.NotFound();
            }
            order.ChangeStatus(OrderStatus.Shipping);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
