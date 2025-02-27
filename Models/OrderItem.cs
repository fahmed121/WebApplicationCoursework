using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplicationCourseWork.Models
{
    // class represents the link table in the many to many relationship between Order and item
    public class OrderItem
    {

        public int OrderID {get; set;}
        public int ItemID {get; set;}
        public int Quantitiy {get; set;}

        [JsonIgnore]
        public Order Order {get; set;}
        [JsonIgnore]
        public Item Item {get; set;}
    }
}