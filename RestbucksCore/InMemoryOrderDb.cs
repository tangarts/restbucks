// <copyright file="InMemoryOrderDb.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace RestbucksCore
{
    public class InMemoryOrderDb
    {
        private static int orderCounter = 0;

        private Dictionary<int, Order> data = new Dictionary<int, Order>();

        public int Save(Order order)
        {
            int id = orderCounter;
            this.Save(id, order);
            orderCounter++;
            return id;
        }

        public void Save(int id, Order order) => this.data.Add(id, order);

        public void Update(int id, Order order) => this.data[id] = order;

        public bool Exists(int id) => this.data.ContainsKey(id);

        public Order? GetOrder(int id)
        {
            if (this.data.ContainsKey(id))
            {
                return this.data[id];
            }

            return null;
        }

        // todo check if in db
        public bool Delete(int id) => this.data.Remove(id);
    }
}