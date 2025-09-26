using Common.Application;
using MediatR;
using Shop.Application.Sellers.AddInventory;
using Shop.Application.Sellers.EditInventory;
using Shop.Query.Products.GetById;
using Shop.Query.Sellers.DTOs;
using Shop.Query.Sellers.Inventories.GetById;
using Shop.Query.Sellers.Inventories.GetList;
using Shop.Query.Sellers.Inventories.GetProductById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Shop.Presentation.Facade.Sellers.Inventories
{
    internal class SellerInventoryFacade : ISellerInventoryFacade
    {
        private readonly IMediator _mediator;

        public SellerInventoryFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> AddInventory(AddSellerInventoryCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditInventory(EditSellerInventoryCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<InventoryDto?> GetById(long inventoryId)
        {
            return await _mediator.Send(new GetSelllerInventoryByIdQuery(inventoryId));
        }

        public async Task<List<InventoryDto>> GetByProductId(long productId)
        {
            return await _mediator.Send(new GetInventoriesByProductIdQuery(productId));
        }

        public async Task<List<InventoryDto>> GetList(long sellerId)
        {
            return await _mediator.Send(new GetInventoriesQuery(sellerId));
        }
    }
}
