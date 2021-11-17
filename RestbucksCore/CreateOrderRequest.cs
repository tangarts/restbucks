using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace RestbucksCore
{
    public enum Location { TakeAway, DrinkIn };
    public enum Status { Preparing, AwaitingPayment, Served };


    [XmlRoot(Namespace = "http://restbucks.com")]
    [XmlType(TypeName = "order")]
    public class CreateOrderRequest
    {
        //public Order()
        //{
        //    ConsumeLocation = Location.TakeAway;
        //    OrderStatus = Status.Preparing;
        //    Items = new List<Item>
        //    {
        //        new Item { Name = Item.Coffee.latte, DrinkSize = Item.Size.small, MilkType = Item.Milk.whole, Quantity = 2 },
        //        new Item { Name = Item.Coffee.cappuccino, DrinkSize = Item.Size.large, MilkType = Item.Milk.skim, Quantity = 1 }
        //    };
        //}

        
        
        [XmlElement(ElementName = "location")]
        [JsonProperty(PropertyName = "location")]
        public Location ConsumeLocation { get; set; }

        // [Required]
        [XmlElement(ElementName = "items")]
        [JsonProperty(PropertyName = "items")]
        public List<Item> Items { get; set; }
    }
}
