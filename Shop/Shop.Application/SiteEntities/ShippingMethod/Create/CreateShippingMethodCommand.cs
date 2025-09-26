using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SiteEntities.ShippingMethod.Create
{
    public class CreateShippingMethodCommand:IBaseCommand
    {
        public string Title { get; set; }
        public int Cost { get; set; }
    }
}
