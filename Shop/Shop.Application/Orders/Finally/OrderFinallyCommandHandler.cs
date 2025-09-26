using Common.Application;
using Shop.Domain.OrderAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders.Finally
{
    internal class OrderFinallyCommandHandler : IBaseCommandHandler<OrderFinallyCommand>
    {
        private readonly IOrderRepository _repository;

        public OrderFinallyCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(OrderFinallyCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetTracking(request.OrderId);
            if(order == null)
            {
                return OperationResult.NotFound();
            }
            order.Finally();
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
