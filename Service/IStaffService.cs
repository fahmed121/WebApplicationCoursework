using WebApplicationCourseWork.Models;

public interface IStaffService
{
    Task<IEnumerable<Staff>> GetAllStaffsAsync();
    Task<Staff> GetStaffbyIdAsync(int StaffID);
    Task AddStaffAsync(Staff staff);
    Task UpdateStaffAsync(int StaffID, Staff staff);
    Task DeleteStaffAsync(int StaffID);
}