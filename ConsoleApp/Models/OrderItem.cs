// <copyright file="CreateOrderRequest.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace RestbucksCore
{
    public class OrderItem
    {
        public Location ConsumeLocation { get; set; }

        public List<Item> Items { get; set; }
    }
}
