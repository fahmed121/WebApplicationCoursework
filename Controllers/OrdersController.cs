using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationCourseWork.Models;
using WebApplicationCourseWork.Data;
using WebApplicationCourseWork.DTO;
namespace WebApplicationCourseWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly FastFoodContext _context;

        public OrdersController(FastFoodContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders()
        {
            var order = await _context.Orders.ToListAsync(); 

            var orderDto = order.Select(o => new OrderDTO
            {
                Id = o.OrderID,
                OrderDetails = o.OrderDetails,
                OrderStatus = o.OrderStatus,
                OrderDate  = o.OrderDate,
                TotalPrice = o.TotalPrice,
                CustID = o.CustID,
                
                
                // OrderItemsDTO = o.OrderItems.Select(oi => new OrderItemDTO 
                // {
                //  OrderID = oi.OrderID,
                //  ItemID = oi.ItemID,
                //  Quantity = oi.Quantity
                    
                    
                // }).ToList()

            }).ToList();
            return Ok(orderDto);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }
            var orderDto = new OrderDTO
            {
                Id = order.OrderID,
                OrderDetails = order.OrderDetails,
                OrderStatus = order.OrderStatus,
                OrderDate  = order.OrderDate,
                TotalPrice = order.TotalPrice,
                CustID = order.CustID,
            };

            return Ok(orderDto);
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, OrderDTO orderDto)
        {
            var order = await _context.Orders.FindAsync(id);
            if (id != order.OrderID)
            {
                return BadRequest();
            }
                order.OrderDetails = orderDto.OrderDetails ?? order.OrderDetails;
                order.OrderStatus = orderDto.OrderStatus ?? order.OrderStatus;
                order.OrderDate  = orderDto.OrderDate;
                order.TotalPrice = orderDto.TotalPrice;
                
                
            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(OrderDTO orderdto)
        {
            var order = new Order
            {
                OrderDetails = orderdto.OrderDetails,
                OrderStatus = orderdto.OrderStatus,
                OrderDate = orderdto.OrderDate,
                TotalPrice = orderdto.TotalPrice
            };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderID }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }
    }
}
