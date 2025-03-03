using System.Text.Json.Serialization;
using WebApplicationCourseWork.Models;
using System.ComponentModel.DataAnnotations;
namespace WebApplicationCourseWork.DTO
{
    public class OrderDTO
    {
        public int Id {get; set;}
        
        public string? OrderDetails {get; set;} 
        public string? OrderStatus {get; set;}
        public DateTime OrderDate {get; set;} = DateTime.UtcNow;
        [Required]
        public decimal TotalPrice {get; set;}
        [Required]
        public int CustID {get; set;}   
        // [JsonIgnore] // commented out due to circular logic i need an order item to create an order but to create an order item i need an order ID 
        // public List<OrderItemDTO> OrderItemsDTO {get; set;} 
    }
}