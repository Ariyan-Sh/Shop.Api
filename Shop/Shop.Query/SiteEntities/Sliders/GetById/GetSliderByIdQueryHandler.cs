using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.SiteEntities.Sliders.GetById
{
    internal class GetSliderByIdQueryHandler : IQueryHandler<GetSliderByIdQuery, SliderDto>
    {
        private readonly ShopContext _context;

        public GetSliderByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<SliderDto> Handle(GetSliderByIdQuery request, CancellationToken cancellationToken)
        {
            var slider = await _context.Sliders.FirstOrDefaultAsync(d=>d.Id == request.SliderId,cancellationToken);
            if (slider == null)
            {
                return null;
            }
            return new SliderDto()
            {
                Id = slider.Id,
                CreationDate = slider.CreationDate,
                ImageName = slider.ImageName,
                Link = slider.Link,
                Title = slider.Title
            };
        }
    }
}
