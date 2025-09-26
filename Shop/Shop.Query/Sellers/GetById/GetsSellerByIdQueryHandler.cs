using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Sellers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Sellers.GetById
{
    internal class GetsSellerByIdQueryHandler : IQueryHandler<GetsSellerByIdQuery, SellerDto?>
    {
        private readonly ShopContext _context;

        public GetsSellerByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<SellerDto?> Handle(GetsSellerByIdQuery request, CancellationToken cancellationToken)
        {
            var seller = await _context.Sellers.FirstOrDefaultAsync(s=>s.Id == request.SellerId,cancellationToken);
            if (seller == null)
            {
                return null;
            }
            return seller.Map();
        }
    }
}
