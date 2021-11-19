namespace RestbucksCore
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class EFOrderDb : IDatabase
    {
        private readonly OrderDbContext context;

        public EFOrderDb(OrderDbContext context)
        {
            this.context = context;
        }

        public bool DeleteOrder(int id)
        {
            Order? order = this.context.Orders.FirstOrDefault(o => o.Id == id);
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
            Order? order = this.context.Orders.Find(id);
            return order;
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
