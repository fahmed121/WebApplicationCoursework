using WebApplicationCourseWork.Models;

public interface IOrderService
{
    Task<IEnumerable<Order>>GetAllOrdersAsync();
    Task<Order> GetOrderByIdAsync(int OrderID);
    Task AddOrderAsync(Order order);
    Task UpdateOrderAsync(int OrderID ,Order order);
    Task DeleteOrderAsync(int OrderID);
}