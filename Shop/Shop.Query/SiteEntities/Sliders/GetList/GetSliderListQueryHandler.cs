using Common.Query;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.SiteEntities.Sliders.GetList
{
    internal class GetSliderListQueryHandler : IQueryHandler<GetSliderListQuery, List<SliderDto>>
    {
        private readonly ShopContext _context;

        public GetSliderListQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<SliderDto>> Handle(GetSliderListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Sliders.OrderByDescending(f => f.Id).Select(slider => new SliderDto()
            {
                Id = slider.Id,
                CreationDate = slider.CreationDate,
                ImageName = slider.ImageName,
                Link = slider.Link,
                Title = slider.Title
            }).ToListAsync(cancellationToken);
        }
    }
}
