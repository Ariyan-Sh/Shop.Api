using Common.Query;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Sellers.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Sellers.GetByUserId
{
    internal class GetSellerByUserIdQueryHandler : IQueryHandler<GetSellerByUserIdQuery, SellerDto?>
    {
        private readonly ShopContext _context;

        public GetSellerByUserIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<SellerDto?> Handle(GetSellerByUserIdQuery request, CancellationToken cancellationToken)
        {
            var seller = await _context.Sellers.FirstOrDefaultAsync
                (f => f.Id == request.UserId, cancellationToken);
            return seller.Map();
        }
    }
}