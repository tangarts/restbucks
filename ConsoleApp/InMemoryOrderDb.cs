// <copyright file="InMemoryOrderDb.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Restbucks.Core
{
    using Restbucks.Core.Models;

    public class InMemoryOrderDb : IDatabase
    {
        private static int orderCounter = 0;

        private Dictionary<int, Order> orders = new ();
        private Dictionary<int, Payment> payments = new ();

        public Order CreateOrder(Order order)
        {
            int id = orderCounter;
            this.orders.Add(id, order);
            orderCounter++;
            return order;
        }

        public void UpdateOrder(Order order) => this.orders[order.Id] = order;

        public bool Exists(int id) => this.orders.ContainsKey(id);

        public Order? GetOrder(int id)
        {
            if (this.orders.ContainsKey(id))
            {
                return this.orders[id];
            }
            return null;
        }

        public bool DeleteOrder(int id) => this.orders.Remove(id);

        public void PutPayment(int id, Payment payment) => this.payments.Add(id, payment);

        public Payment GetPayment(int id) => this.payments[id];
    }
}