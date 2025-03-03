using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WebApplicationCourseWork.Models;
using WebApplicationCourseWork.Data;

public class StaffServices : IStaffService
{    
    public readonly FastFoodContext _context;

    public StaffServices(FastFoodContext context){
        _context = context;
    }
    async Task<IEnumerable<Staff>> IStaffService.GetAllStaffsAsync()
    {
        return await _context.Staff.ToListAsync();
    }

    async Task IStaffService.AddStaffAsync(Staff staff)
    {
        _context.Staff.Add(staff);
        await _context.SaveChangesAsync();
    }

    async Task IStaffService.DeleteStaffAsync(int StaffID)
    {
        var staff = await _context.Staff.FindAsync(StaffID);
        if (staff != null)
        {
            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();
        }
    }


     async Task<Staff> IStaffService.GetStaffbyIdAsync(int StaffID)
    {
     
        return await _context.Staff.FindAsync(StaffID);
    }

     async Task IStaffService.UpdateStaffAsync(int StaffID, Staff staff)
    {
        _context.Entry(staff).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}