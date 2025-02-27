using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAplicationCourseWork.Models
{
    public class Staff
    {
    public int StaffID {get; set;}
    public string Name {get; set;}
    public string Email{get; set;}
    
    [JsonIgnore]
    // List of orders to represent the many part of the One to many relation ship between Order and Staff 
    public List<Order> Orders {get; set;} // the reason for this is to represent all the orders made by a certain staff member
    }
}