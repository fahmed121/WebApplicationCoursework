using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAplicationCourseWork.Models
{
    public class Customer
    {
        [Key]
        public int CustID {get; set;}
        public string CustFirstName {get; set;}
        public string CustLastName {get; set;}
        public int Telphone {get; set;}
        public string CustEmail {get; set;}
        public List<Order> Orders {get; set;} // representas many side of relationship with orders
    }
}