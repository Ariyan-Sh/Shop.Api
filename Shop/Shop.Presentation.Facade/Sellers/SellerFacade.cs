using Common.Application;
using MediatR;
using Shop.Application.Sellers.Create;
using Shop.Application.Sellers.Edit;
using Shop.Query.Sellers.DTOs;
using Shop.Query.Sellers.GetByFilter;
using Shop.Query.Sellers.GetById;
using Shop.Query.Sellers.GetByUserId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Shop.Presentation.Facade.Sellers
{
    internal class SellerFacade : ISellerFacade
    {
        private readonly IMediator _mediator;

        public SellerFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> CreateSeller(CreateSellerCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditSeller(EditSellerCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<SellerDto?> GetSellerById(long id)
        {
            return await _mediator.Send(new GetsSellerByIdQuery(id));
        }

        public async Task<SellerDto?> GetSellerByUserId(long userId)
        {
            return await _mediator.Send(new GetSellerByUserIdQuery(userId));
        }

        public async Task<SellerFilterResult> GetsellersByFilter(SellerFilterPrarams filterPrarams)
        {
            return await _mediator.Send(new GetSellerByFilterQuery(filterPrarams));
        }
    }
}
