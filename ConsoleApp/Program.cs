// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using RestbucksCore;

Func<object, string> dump = (object obj) => JsonConvert.SerializeObject(obj, Formatting.Indented);
//var fakeItem = FakeOrder.FakeItem();
//Console.WriteLine(dump(fakeItem.Generate()));


var fakeOrders = FakeOrder.GenerateFakeOrder(maxOrderItems: 4).Generate();
Console.WriteLine(dump(fakeOrders));