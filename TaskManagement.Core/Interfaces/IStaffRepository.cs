using TaskManagement.Core.Models;

namespace TaskManagement.Data.Repositories
{
    public interface IStaffRepository
    {
        Task<bool> CreateAsync(StaffModel staff);
        Task<bool> DeleteAsync(StaffModel staff);
        Task<StaffModel> GetAsync(int id);
        Task<bool> UpdateAsync(StaffModel staff);
    }
}