using Common.Query.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Sellers.DTOs
{
    public class SellerFilterPrarams:BaseFilterParam
    {
        public string ShopName { get; set; }
        public string NationalCode { get; set; }
    }
}
