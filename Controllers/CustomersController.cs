using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationCourseWork.Models;
using WebApplicationCourseWork.Data;
using AutoMapper;
using WebApplicationCourseWork.DTO;
namespace WebApplicationCourseWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly FastFoodContext _context;

        public CustomersController(FastFoodContext context)
        {
            _context = context;
        }
        //private readonly IMapper _mapper;

        // public CustomersController(FastFoodContext context, IMapper mapper)
        // {
        //     _context = context;
        //     _mapper = mapper;
        // }
        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            var customers = await _context.Customer.ToListAsync();
            //var CustomerDtos = _mapper.Map<CustomerDTO>(customers);
            var customerDTOS = customers.Select(c => new CustomerDTO
            {
                CustID = c.CustID,
                CustFirstName = c.CustFirstName,
                CustLastName = c.CustLastName,
                Telephone = c.Telephone,
                CustEmail = c.CustEmail

            }).ToList();
            return Ok(customerDTOS);
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customer.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }
            // var CustomerDtos = _mapper.Map<CustomerDTO>(customer);
            var customerDtos = new CustomerDTO
            {
                CustID = customer.CustID,
                CustFirstName = customer.CustFirstName,
                CustLastName = customer.CustLastName,
                Telephone = customer.Telephone,
                CustEmail = customer.CustEmail
            };
            return Ok(customerDtos);
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, CustomerDTO customerDTO)
        {
            if (id != customerDTO.CustID)
            {
                return BadRequest();
            }
            var customer = await _context.Customer.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }
            customer.CustFirstName = customerDTO.CustFirstName ?? customer.CustFirstName; // added this because if i didnt update a field it would change to null
            customer.CustLastName = customerDTO.CustLastName ?? customer.CustLastName; // ?? just means that if the first item is null use the second item.
            customer.Telephone = customerDTO.Telephone ?? customer.Telephone;
            customer.CustEmail = customerDTO.CustEmail ?? customer.CustEmail;
            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> PostCustomer(CustomerDTO customerDTO)
        {
            //var CustomerDtos = _mapper.Map<Customer>(customerDto);
            var customer = new Customer
            {
                CustID = customerDTO.CustID,
                CustFirstName = customerDTO.CustFirstName,
                CustLastName = customerDTO.CustLastName,
                Telephone = customerDTO.Telephone,
                CustEmail = customerDTO.CustEmail
            };
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.CustID }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.CustID == id);
        }
    }
}
