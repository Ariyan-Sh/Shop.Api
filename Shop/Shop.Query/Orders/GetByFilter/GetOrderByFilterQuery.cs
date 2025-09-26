﻿using Common.Query;
using Shop.Query.Orders.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Orders.GetByFilter
{
    public class GetOrderByFilterQuery : QueryFilter<OrderFilterResult, OrderFilterParams>
    {
        public GetOrderByFilterQuery(OrderFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
