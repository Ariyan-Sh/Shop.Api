﻿using Common.Query;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.OrderAgg.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Orders.DTOs
{
    public class OrderDto:BaseDto
    {
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        public OrderStatus Status { get; set; }
        public OrderDiscount? Discount { get; set; }
        public OrderAddress? Address { get; set; }
        public OrderShippingMethod? ShippingMethod { get; set; }
        public List<OrderItemDto> Items { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
