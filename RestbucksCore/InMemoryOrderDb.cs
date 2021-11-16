namespace RestbucksCore
{
    public class InMemoryOrderDb : Dictionary<int, Order>
    {
        // For testing only!
        static InMemoryOrderDb()
        {
            Database.Add(1, new Order());
        }

        private static int orderCounter = 1;

        public static InMemoryOrderDb Database { get; } = new InMemoryOrderDb();

        public int Save(Order order)
        {
            int id = orderCounter;
            Save(id, order);
            orderCounter++;
            return id;
        }

        public void Save(int id, Order order) => this.Add(id, order);
        public void Update(int id, Order order) => this[id] = order; 
        public void Save() { return; }


        public bool Exists(int id) => this.ContainsKey(id);

        public Order? GetOrder(int id)
        {
            if (this.ContainsKey(id))
            {
                return this[id];
            }

            return null;
        }

        // todo check if in db
        public bool Delete(int id) => this.Remove(id);
    }
}