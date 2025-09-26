using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Products.GetBySlug
{
    internal class GetProductBySlugQueryHandler : IQueryHandler<GetProductBySlugQuery, ProductDto>
    {
        private readonly ShopContext _context;
        public async Task<ProductDto> Handle(GetProductBySlugQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
            .FirstOrDefaultAsync(f => f.Slug == request.Slug, cancellationToken);
            var model = product.Map();

            if (model == null)
                return null;

            await model.SetCategories(_context);
            return model;
        }
    }
}
