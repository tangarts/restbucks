// <copyright file="Item.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Restbucks.Core.Models
{
    public class Item
    {
        public Coffee Name { get; set; }

        public int Quantity { get; set; }

        public Milk MilkType { get; set; }

        public Size DrinkSize { get; set; }
    }
}
