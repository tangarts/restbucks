using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace RestbucksCore
{
    public enum Coffee { latte, cappuccino, espresso };
    public enum Milk { skim, semi, whole };
    public enum Size { small, medium, large };
    public class Item
    {

        // public Item() { }

        //public Item(Coffee name, int quantity, Milk milk, Size size)
        //{
        //    this.Name = name;
        //    this.Quantity = quantity;
        //    this.MilkType = milk;
        //    this.DrinkSize = size;
        //}

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public Coffee Name { get; set; }
        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }
        [JsonProperty(PropertyName = "milkType")]
        public Milk MilkType { get; set; }
        [JsonProperty(PropertyName = "drinkSize")]
        public Size DrinkSize { get; set; }
    }
}
