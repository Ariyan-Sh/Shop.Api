﻿using Common.Application;
using MediatR;
using Shop.Application.SiteEntities.ShippingMethod.Create;
using Shop.Application.SiteEntities.ShippingMethod.Delete;
using Shop.Application.SiteEntities.ShippingMethod.Edit;
using Shop.Query.SiteEntities.DTOs;
using Shop.Query.SiteEntities.ShippingMethods.GetById;
using Shop.Query.SiteEntities.ShippingMethods.GetList;

namespace Shop.Presentation.Facade.Siteentities.ShippingMethods
{
    public class ShippingMethodFacade : IShippingMethodFacade
    {
        private readonly IMediator _mediator;

        public ShippingMethodFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> Create(CreateShippingMethodCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Delete(long id)
        {
           return await _mediator.Send(new DeleteShippingMethodCommand(id));
        }

        public async Task<OperationResult> Edit(EditShippingMethodCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<List<ShippingMethodDto>> GetList()
        {
            return await _mediator.Send(new GetShippingMethodByListQuery());
        }

        public async Task<ShippingMethodDto?> GetShippingMethodById(long id)
        {
            return await _mediator.Send(new GetShippingMethodByIdQuery(id));
        }
    }
}
