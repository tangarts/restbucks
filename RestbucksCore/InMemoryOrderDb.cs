// <copyright file="InMemoryOrderDb.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace RestbucksCore
{
    public class InMemoryOrderDb
    {
        private static int orderCounter = 0;

        private Dictionary<int, Order> orders = new ();
        private Dictionary<int, Payment> payments = new ();

        public int Save(Order order)
        {
            int id = orderCounter;
            this.Save(id, order);
            orderCounter++;
            return id;
        }

        public void Save(int id, Order order) => this.orders.Add(id, order);

        public void Update(int id, Order order) => this.orders[id] = order;

        public bool Exists(int id) => this.orders.ContainsKey(id);

        public Order? GetOrder(int id)
        {
            if (this.orders.ContainsKey(id))
            {
                return this.orders[id];
            }

            return null;
        }

        public bool Delete(int id) => this.orders.Remove(id);

        public  void PutPayment(int id, Payment payment)
        {
            this.payments.Add(id, payment);
        }

        public Payment GetPayment(int id)
        {
            return this.payments[id];
        }
    }
}