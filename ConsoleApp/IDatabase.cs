// <copyright file="IDatabase.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace RestbucksCore
{
    public interface IDatabase
    {
        public int Save(Order order);

        public void Update(int id, Order order);

        public bool Exists(int id);

        public bool Delete(int id);

        public Order? GetOrder(int id);

    }
}
