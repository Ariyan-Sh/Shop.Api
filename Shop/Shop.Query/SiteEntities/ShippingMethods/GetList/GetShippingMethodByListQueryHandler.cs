using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.SiteEntities.Repository;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Query.SiteEntities.ShippingMethods.GetList
{
    internal class GetShippingMethodByListQueryHandler : IQueryHandler<GetShippingMethodByListQuery, List<ShippingMethodDto>>
    {
        private readonly ShopContext _context;

        public GetShippingMethodByListQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<ShippingMethodDto>> Handle(GetShippingMethodByListQuery request, CancellationToken cancellationToken)
        {
            return await _context.shippingMethods.Select(s => new ShippingMethodDto
            {
                Id = s.Id,
                CreationDate = s.CreationDate,
                Title = s.Title,
                Cost = s.Cost,
            }).ToListAsync(cancellationToken);
        }
    }
}
