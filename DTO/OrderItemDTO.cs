namespace WebApplicationCourseWork.DTO
{
    public class OrderItemDTO
     {
    //     public int OrderID {get; set;}commented out due to circular logic i need an order item to create an order but to create an order item i need an order ID 
        public int ItemID {get; set;}
        public int Quantity {get; set;}  
    
    }
}