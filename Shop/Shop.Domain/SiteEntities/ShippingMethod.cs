using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.SiteEntities
{
    public class ShippingMethod:BaseEntity
    {
        public ShippingMethod(string title, int cost)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            Title = title;
            Cost = cost;
        }

        public string Title { get; private set; }
        public int Cost { get; private set; }

        public void Edit(int cost, string title)
        {
            NullOrEmptyDomainDataException.CheckString(title,nameof(title));
            Cost = cost;
            Title = title;
        }
    }
}
