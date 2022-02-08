// <copyright file="Order.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Restbucks.Web
{
    using System.Collections.Generic;
    using Restbucks.Core.Models;

    public class OrderDTO
    {
        public OrderDTO() { }

        public OrderDTO(Order order) =>
            (Id, ConsumeLocation, Items) = (order.Id, order.ConsumeLocation, order.Items);

        public int Id { get; set; }

        public Location ConsumeLocation { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();
    }
}
