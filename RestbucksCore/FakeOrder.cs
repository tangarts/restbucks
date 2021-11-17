// <copyright file="FakeOrder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Bogus;

namespace RestbucksCore
{
    public static class FakeOrder
    {
        public static Faker<Item> FakeItem()
        {
            var items = new Faker<Item>()
                .RuleFor(i => i.Id, f => (-1 - f.IndexGlobal))
                .RuleFor(i => i.Name, f => f.PickRandom<Coffee>())
                .RuleFor(i => i.Quantity, f => f.Random.Int(1, 5))
                .RuleFor(i => i.MilkType, f => f.PickRandom<Milk>())
                .RuleFor(i => i.DrinkSize, f => f.PickRandom<Size>());

            return items;
        }

        public static Faker<Order> GenerateFakeOrder(int maxOrderItems)
        {
            var faker = new Faker();
            int numberOfOrderItems = faker.Random.Number(1, maxOrderItems);
            Faker<Order> order = new Faker<Order>()
                   .RuleFor(i => i.Id, f => (-1 - f.IndexGlobal))
                   .RuleFor(i => i.ConsumeLocation, f => f.PickRandom<Location>())
                   .RuleFor(i => i.OrderStatus, f => f.PickRandom<Status>())
                   .RuleFor(i => i.Items,
                            FakeItem()
                            .Generate(numberOfOrderItems)
                            .ToList());

            return order;
        }


    }
}
