using WebApplicationCourseWork.Models;

public interface ICustomerService
{
    Task<IEnumerable<Customer>>GetAllCustomersAsync();
    Task<Customer> GetCustomerByIdAsync(int CustID);
    Task AddCustomerAsync(Customer customer);
    Task UpdateCustomerAsync(int CustID, Customer customer);
    Task DeleteCustomerAsync(int CustID);
}