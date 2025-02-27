using System.Text.Json.Serialization;
using WebApplicationCourseWork.Models;

namespace WebApplicationCourseWork.DTO
{
    public class OrderDTO
    {
        public int Id {get; set;}
        public string? OrderDetails {get; set;} 
        public string? OrderStatus {get; set;}
        public DateTime OrderDate {get; set;} = DateTime.UtcNow;
        public decimal TotalPrice {get; set;}
        public int CustID {get; set;}   

        public List<OrderItemDTO> OrderItems {get; set;} // using the DTO instead of Entity
    }
}