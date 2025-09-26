using Common.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Products.DTOs
{
    public class ProductFilterData:BaseDto
    {
        public string Title { get; set; }
        public string ImageName { get; set; }
        public string Slug { get; set; }
    }
}
