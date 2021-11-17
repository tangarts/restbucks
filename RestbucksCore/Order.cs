using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace RestbucksCore
{
    public class Order
    {
        //public Order()
        //{
        //    OrderStatus = Status.Preparing; // unpaid
        //    Items = new List<Item>();
   
        //}

        
        public int Id { get; set; }

        public Location ConsumeLocation { get; set; }

        public List<Item> Items { get; set; }

        public Status OrderStatus { get; set; }
    }
}
