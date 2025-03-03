using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WebApplicationCourseWork.Models;
using WebApplicationCourseWork.Data;
using Org.BouncyCastle.Bcpg.OpenPgp;

public class CustomerServices : ICustomerService
{
    public readonly FastFoodContext _context;

    public CustomerServices(FastFoodContext context)
    {
        _context = context;
    }
    async Task<IEnumerable<Customer>> ICustomerService.GetAllCustomersAsync()
    {
        return await _context.Customer.ToListAsync();
    }

    async Task ICustomerService.AddCustomerAsync(Customer customer)
    {
        _context.Customer.Add(customer);
        await _context.SaveChangesAsync();
    }

    async Task ICustomerService.DeleteCustomerAsync(int CustID)
    {
        var Customer = await _context.Customer.FindAsync(CustID);
        if (Customer != null)
        {
            _context.Customer.Remove(Customer);
            await _context.SaveChangesAsync();
        }
    }



    async Task ICustomerService.UpdateCustomerAsync(int CustID, Customer customer)
    {
        _context.Entry(customer).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    async Task<Customer> ICustomerService.GetCustomerByIdAsync(int CustID)
    {
        var Customer = await _context.Customer.FindAsync(CustID);
        return Customer;
    }
}