using Common.Query;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Categories.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Categories.GetByParentId
{
    internal class GetCategoryByParentIdQueryHandler:IQueryHandler<GetCategoryByParentIdQuery, List<ChildCategoryDto>>
    {
        private readonly ShopContext _context;

        public GetCategoryByParentIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<ChildCategoryDto>> Handle(GetCategoryByParentIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Categories.Where(r => r.ParentId == request.ParentId).ToListAsync(cancellationToken);
            return result.MapChildren();
        }
    }
}
