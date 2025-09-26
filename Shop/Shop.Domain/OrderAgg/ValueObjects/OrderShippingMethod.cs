using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg.ValueObjects
{
    public class OrderShippingMethod:ValueObject
    {
        public OrderShippingMethod(string shippingType, int shippingcost)
        {
            ShippingType = shippingType;
            Shippingcost = shippingcost;
        }

        public string ShippingType { get; private set; }
        public int Shippingcost { get; private set; }
    }
}
