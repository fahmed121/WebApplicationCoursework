using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace WebApplicationCourseWork.Models
{
    public class Item
    {
        public int ItemID {get; set;}
        public string ItemName {get; set;}
        public decimal Price {get; set;}
        [JsonIgnore]
        public List<OrderItem>? Orderitems {get; set;}
    }
}