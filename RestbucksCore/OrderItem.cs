// <copyright file="CreateOrderRequest.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace RestbucksCore
{
    public class OrderItem
    {
        // public Order()
        // {
        //    ConsumeLocation = Location.TakeAway;
        //    OrderStatus = Status.Preparing;
        //    Items = new List<Item>
        //    {
        //        new Item { Name = Item.Coffee.latte, DrinkSize = Item.Size.small, MilkType = Item.Milk.whole, Quantity = 2 },
        //        new Item { Name = Item.Coffee.cappuccino, DrinkSize = Item.Size.large, MilkType = Item.Milk.skim, Quantity = 1 }
        //    };
        // }

        public Location ConsumeLocation { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();
    }
}
