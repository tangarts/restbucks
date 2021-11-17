// <copyright file="Order.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace RestbucksCore
{
    using System.Collections.Generic;

    public class Order
    {
        public int Id { get; set; }

        public Location ConsumeLocation { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();

        public Status OrderStatus { get; set; } 
    }
}
