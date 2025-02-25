using System.Collections.Generic;

namespace WebAplicationCourseWork.Models
{
    public class Item
    {
        public int ItemID {get; set;}
        public string ItemName {get; set;}
        public double Price {get; set;}
        public List<OrderItem> Orderitems {get; set;}
    }
}