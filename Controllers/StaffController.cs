using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationCourseWork.Models;
using WebApplicationCourseWork.Data;
using System.Xml;
using WebApplicationCourseWork.DTO;
namespace WebApplicationCourseWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly FastFoodContext _context;

        public StaffController(FastFoodContext context)
        {
            _context = context;
        }

        // GET: api/Staff
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaff()
        {
            var staff = await _context.Staff.ToListAsync();
            var staffDto = staff.Select(s => new StaffDTO
            {
                StaffID = s.StaffID,
                Name = s.Name
            }).ToList();
            return Ok(staffDto);
        }

        // GET: api/Staff/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaff(int id)
        {
            var staff = await _context.Staff.FindAsync(id);

            if (staff == null)
            {
                return NotFound();
            }
            var staffdto = new StaffDTO
            {
                Name = staff.Name
            };

            return Ok(staffdto);
        }

        // PUT: api/Staff/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(int id, StaffDTO staffDTO)
        {
            var staff = await _context.Staff.FindAsync(id);
            if (id != staff.StaffID)
            {
                return BadRequest();
            }
            staff.Name = staffDTO.Name ?? staff.Name;

            _context.Entry(staff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(id))
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

        // POST: api/Staff
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff(StaffDTO staffDTO)
        {
            var staff = new Staff
            {

                Name = staffDTO.Name
            };
            _context.Staff.Add(staff);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStaff", new { id = staff.StaffID }, staff);
        }

        // DELETE: api/Staff/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var staff = await _context.Staff.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StaffExists(int id)
        {
            return _context.Staff.Any(e => e.StaffID == id);
        }
    }
}
