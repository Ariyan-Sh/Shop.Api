using Common.Query;
using Shop.Query.Sellers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Sellers.GetByFilter
{
    public class GetSellerByFilterQuery : QueryFilter<SellerFilterResult, SellerFilterPrarams>
    {
        public GetSellerByFilterQuery(SellerFilterPrarams filterParams) : base(filterParams)
        {
        }
    }
}
