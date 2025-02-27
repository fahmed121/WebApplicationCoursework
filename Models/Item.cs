using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace WebAplicationCourseWork.Models
{
    public class Item
    {
        public int ItemID {get; set;}
        public string ItemName {get; set;}
        public double Price {get; set;}
        [JsonIgnore]
        public List<OrderItem>? Orderitems {get; set;}
    }
}