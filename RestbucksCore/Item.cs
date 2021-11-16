using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace RestbucksCore
{
    public class Item
    {

        public enum Coffee { latte, cappuccino, espresso };
        public enum Milk { skim, semi, whole };
        public enum Size { small, medium, large };

        // public Item() { }

        //public Item(Coffee name, int quantity, Milk milk, Size size)
        //{
        //    this.Name = name;
        //    this.Quantity = quantity;
        //    this.MilkType = milk;
        //    this.DrinkSize = size;
        //}

        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public Coffee Name { get; set; }
        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }
        [JsonProperty(PropertyName = "milkType")]
        public Milk MilkType { get; set; }
        [JsonProperty(PropertyName = "drikSize")]
        public Size DrinkSize { get; set; }
    }
}
