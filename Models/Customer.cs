using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace WebApplicationCourseWork.Models
{
    public class Customer
    {
        [Key] //data annotation because CustID was not being recognised as a primary key
        public int CustID {get; set;}
        public string CustFirstName {get; set;}
        public string CustLastName {get; set;}
        public string Telephone {get; set;}
        public string CustEmail {get; set;}
        
        [JsonIgnore]
        public List<Order>? Orders {get; set;} // represents many side of relationship with orders
    }
}