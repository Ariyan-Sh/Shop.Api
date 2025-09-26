using Common.Query;
using Dapper;
using Shop.Domain.ProductAgg;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Sellers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Sellers.Inventories.GetProductById
{
    internal class GetInventoriesByProductIdQueryHandler : IQueryHandler<GetInventoriesByProductIdQuery, List<InventoryDto>>
    {
        private readonly DapperContext _context;

        public GetInventoriesByProductIdQueryHandler(DapperContext dapperContext)
        {
            _context = dapperContext;
        }

        public async Task<List<InventoryDto>> Handle(GetInventoriesByProductIdQuery request, CancellationToken cancellationToken)
        {
            using var connection = _context.CreateConnection();
            var sql = @$"SELECt i.Id, i.SellerId, i.ProductId, i.Count, i.Price,
                       i.CreationDate, i.DiscountPercentage, s.ShopName,
                       p.Title as ProductTitle, p.ImageName as ProductImage
                       FROM {_context.Inventories} i inner join {_context.Sellers} s on i.Sellerid = s.Id
                       inner join {_context.Products} p on p.ProductId=p.Id WHERE ProductId=@productId";
            var result = await connection.QueryAsync<InventoryDto>(sql, new { productId = request.productId });
            return result.ToList();
        }
    }
}
