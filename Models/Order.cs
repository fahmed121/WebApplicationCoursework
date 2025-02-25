using System.Collections.Generic;

namespace WebAplicationCourseWork.Models
{
    public class Order 
    {
        public int OrderID {get; set;}
        public string OrderDetails {get; set;}
        public string OrderStatus {get; set;}
        public DateTime OrderDate {get; set;} = DateTime.Now;
        public double TotalPrice {get; set;}
        public int StaffID {get; set;} // Foreign Key referring to Staff table, refers to which staff member made which order
        public int CustID {get; set;}// Foreign Key referring to Customer Table, refers to who the order is for

        public Staff Staff {get; set;} // allows for navigation

        public Customer? Customer {get; set;} // question mark because for this relationship is optional on one side.
        public List<OrderItem> Orderitems {get; set;} 

    }
}