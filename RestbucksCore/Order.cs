using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace RestbucksCore
{
    [XmlRoot(Namespace = "http://restbucks.com")]
    [XmlType(TypeName = "order")]
    public class Order
    {
        public Order()
        {
            ConsumeLocation = Location.TakeAway;
            OrderStatus = Status.Preparing;
            Items = new List<Item>
            {
                new Item { Name = Item.Coffee.latte, DrinkSize = Item.Size.small, MilkType = Item.Milk.whole, Quantity = 2 },
                new Item { Name = Item.Coffee.cappuccino, DrinkSize = Item.Size.large, MilkType = Item.Milk.skim, Quantity = 1 }
            };
        }
        public enum Location { TakeAway, DrinkIn };
        public enum Status { Preparing, AwaitingPayment, Served };

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "location")]
        [JsonProperty(PropertyName = "location")]
        public Location ConsumeLocation { get; set; }

        [XmlElement(ElementName = "items")]
        [JsonProperty(PropertyName = "items")]
        public List<Item> Items { get; set; }

        [XmlElement(ElementName = "status")]
        [JsonProperty(PropertyName = "status")]
        public Status OrderStatus { get; set; }
    }
}
