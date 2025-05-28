using TaskManagement.Core.Models;

namespace TaskManagement.Data.Repositories
{
    public interface IBossRepository
    {
        Task<bool> CreateAsync(BossModel boss);
        Task<bool> DeleteAsync(BossModel boss);
        Task<BossModel> GetByIdAsync(int id);
        Task<bool> UpdateAsync(BossModel boss);
    }
}