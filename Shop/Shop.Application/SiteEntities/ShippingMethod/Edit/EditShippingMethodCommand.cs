using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SiteEntities.ShippingMethod.Edit
{
    public class EditShippingMethodCommand:IBaseCommand
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int Cost { get; set; }
    }
}
