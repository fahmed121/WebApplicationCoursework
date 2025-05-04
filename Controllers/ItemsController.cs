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
        private readonly ILogger<Item> logger;
        public ItemsController(FastFoodContext context, ILogger<Item> logger)
        {
            this.logger = logger;
            _context = context;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            logger.LogInformation("Showing all Items on the menu..");
            var items = await _context.Items.ToListAsync();
            var itemDtos = items.Select(i => new ItemDTO //
            {
                ItemName = i.ItemName,
                Description = i.Description,
                Price = i.Price,
                Quantity = i.Quantity

            }).ToList();
            return Ok(items);

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
                Description = item.Description,
                Price = item.Price,
                Quantity = item.Quantity


            };

            return Ok(itemDto);
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, ItemDTO itemDTO)
        {
            logger.LogInformation("Updating Item");
            var item = await _context.Items.FindAsync(id);
            if (id != item.ItemID)
            {
                return BadRequest();
            }

            item.ItemName = itemDTO.ItemName ?? item.ItemName;
            item.Price = itemDTO.Price;// error here where ?? does not work with decimal
            item.Description = itemDTO.Description;
            item.Quantity = itemDTO.Quantity;


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
                Price = itemdto.Price,
                Description = itemdto.Description,
                Quantity = itemdto.Quantity

            };
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { id = item.ItemID }, item);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            logger.LogInformation("Deleting Item");
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
