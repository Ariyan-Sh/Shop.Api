using Common.Application;
using Shop.Application.SiteEntities.ShippingMethod.Create;
using Shop.Application.SiteEntities.ShippingMethod.Delete;
using Shop.Application.SiteEntities.ShippingMethod.Edit;
using Shop.Query.SiteEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Siteentities.ShippingMethods
{
    public interface IShippingMethodFacade
    {
        Task<OperationResult> Create(CreateShippingMethodCommand command);
        Task<OperationResult> Edit(EditShippingMethodCommand command);
        Task<OperationResult> Delete(long id);

        Task<ShippingMethodDto?> GetShippingMethodById(long id);
        Task<List<ShippingMethodDto>> GetList();

    }
}
