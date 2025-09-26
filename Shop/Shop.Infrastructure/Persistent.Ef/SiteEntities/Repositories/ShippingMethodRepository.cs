using Common.Domain.Repository;
using Shop.Domain.OrderAgg.ValueObjects;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repository;
using Shop.Infrastructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.SiteEntities.Repositories
{
    internal class ShippingMethodRepository : BaseRepository<ShippingMethod>, IShippingMethodRepository
    {
        public ShippingMethodRepository(ShopContext context):base(context)
        {
        }
        public void Delete(ShippingMethod shippingMethod)
        {
            Context.shippingMethods.Remove(shippingMethod);
        }
    }
}
