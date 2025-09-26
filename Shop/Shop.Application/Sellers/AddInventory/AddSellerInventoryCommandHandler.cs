using Common.Application;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Sellers.AddInventory
{
    internal class AddSellerInventoryCommandHandler:IBaseCommandHandler<AddSellerInventoryCommand>
    {
        private readonly ISellerRepository _repository;

        public AddSellerInventoryCommandHandler(ISellerRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult> Handle(AddSellerInventoryCommand request, CancellationToken cancellationToken)
        {
            var seller = await _repository.GetTracking(request.SellerId);
            if(seller == null)
            {
                return OperationResult.NotFound();
            }
            var inventory = new SellerInventory(request.ProductId,request.Count,request.Price,request.PercentageDiscout);
            seller.AddInventory(inventory);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
