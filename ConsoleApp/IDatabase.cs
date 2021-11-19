// <copyright file="IDatabase.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace RestbucksCore
{
    public interface IDatabase
    {
        public Order CreateOrder(Order order);

        public void UpdateOrder(Order order);

        public bool Exists(int id);

        public bool DeleteOrder(int id);

        public Order? GetOrder(int id);

    }
}
