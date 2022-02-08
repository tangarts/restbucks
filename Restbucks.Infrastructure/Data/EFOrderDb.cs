namespace Restbucks.Core
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Restbucks.Core.Models;

    public class EFOrderDb : IOrderRepository
    {
        private readonly AppDbContext context;

        public EFOrderDb(AppDbContext context)
        {
            this.context = context;
        }

        public bool DeleteOrder(int id)
        {
            Order? order = this.context.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return false;
            }
            this.context.Orders.Remove(order);
            // is this right?
            int stateEntries = this.context.SaveChanges();
            return stateEntries != 0;
        }

        public bool Exists(int id)
        {
            return this.context.Orders.Any(x => x.Id == id);
        }

        public Order? GetOrder(int id)
        {
            return this.context.Orders.Find(id);
        }

        public Order CreateOrder(Order order)
        {
            this.context.Orders.Add(order);
            this.context.SaveChanges();
            return order;
        }

        public void UpdateOrder(Order order)
        {
            this.context.Update(order);
            this.context.SaveChanges();
        }
    }
}
