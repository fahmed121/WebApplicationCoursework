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
using Microsoft.Identity.Client;
namespace WebApplicationCourseWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly FastFoodContext _context;

        public ItemsController(FastFoodContext context)
        {
            _context = context;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            var items = await _context.Items.ToListAsync();
            var itemDtos = items.Select(i => new ItemDTO //
            {
                ItemName = i.ItemName,
                Price = i.Price

            }).ToList();
            return Ok(itemDtos);

        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }
            var itemDto = new ItemDTO
            {
                ItemName = item.ItemName,
                Price = item.Price

            };

            return Ok(itemDto);
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, ItemDTO itemDTO)
        {
            var item = await _context.Items.FindAsync(id);
            if (id != item.ItemID)
            {
                return BadRequest();
            }
            
            item.ItemName = itemDTO.ItemName ?? item.ItemName;
            item.Price = itemDTO.Price;// error here where ?? does not work with decimal


            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(ItemDTO itemdto)
        {
            var item = new Item
            {
                ItemName = itemdto.ItemName,
                Price = itemdto.Price
                
            };
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { id = item.ItemID }, item);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemID == id);
        }
    }
}
