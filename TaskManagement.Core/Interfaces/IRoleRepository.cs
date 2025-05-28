using TaskManagement.Core.Models;

namespace TaskManagement.Data.Repositories
{
    public interface IRoleRepository
    {
        Task<bool> CreateAsync(RoleModel role);
        Task<bool> DeleteAsync(RoleModel role);
        Task<RoleModel> GetAsync(int id);
        Task<bool> UpdateAsync(RoleModel role);
    }
}