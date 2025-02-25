using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAplicationCourseWork.Models
{
    // class represents the link table in the many to many relationship between Order and item
    public class OrderItem
    {
        [Key]
        public int OrderItemId {get; set;}
        public int OrderID {get; set;}
        public int ItemID {get; set;}
        public int Quantitiy {get; set;}

        public Order Order {get; set;}
        public Item MenuItem {get; set;}
    }
}