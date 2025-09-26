using Common.Query.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Products.DTOs
{
    public class ProductFilterParams:BaseFilterParam
    {
        public string Title { get; set; }
        public long Id { get; set; }
        public string Slug { get; set; }

    }
}
