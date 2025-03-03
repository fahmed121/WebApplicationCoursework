using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WebApplicationCourseWork.Models;
using WebApplicationCourseWork.Data;
using Org.BouncyCastle.Bcpg.OpenPgp;

public class OrderServices : IOrderService
{
    public readonly FastFoodContext _context;

    public OrderServices(FastFoodContext context)
    {
        _context = context;
    }
    async Task<IEnumerable<Order>> IOrderService.GetAllOrdersAsync()
    {
        return await _context.Orders.ToListAsync();
    }

    async Task IOrderService.AddOrderAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
    }

    async Task IOrderService.DeleteOrderAsync(int OrderID)
    {
        var Order = await _context.Orders.FindAsync(OrderID);
        if (Order != null)
        {
            _context.Orders.Remove(Order);
            await _context.SaveChangesAsync();
        }
    }



    async Task IOrderService.UpdateOrderAsync(int OrderID, Order order)
    {
        
        _context.Entry(order).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    async Task<Order> IOrderService.GetOrderByIdAsync(int OrderID)
    {
        var order = await _context.Orders.FindAsync(OrderID);
        return order;
    }
}