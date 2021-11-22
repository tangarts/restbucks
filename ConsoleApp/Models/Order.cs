// <copyright file="Order.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Restbucks.Core.Models
{
    using System.Collections.Generic;

    public class Order
    {
        public int Id { get; set; }

        public Location ConsumeLocation { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();

        public Status OrderStatus { get; set; }
    }

    public class OrderDto
    {
        public OrderDto() { }

        public OrderDto(Order order) =>
            (Id, ConsumeLocation, Items) = (order.Id, order.ConsumeLocation, order.Items);

        public int Id { get; set; }

        public Location ConsumeLocation { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();
    }
}
