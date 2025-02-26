using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace WebAplicationCourseWork.Models
{
    public class Customer
    {
        [Key] //data annotation because CustID was not being recognised as a primary key
        public int CustID {get; set;}
        public string CustFirstName {get; set;}
        public string CustLastName {get; set;}
        public int Telphone {get; set;}
        public string CustEmail {get; set;}
        [JsonIgnore]
        public List<Order> Orders {get; set;} // representas many side of relationship with orders
    }
}