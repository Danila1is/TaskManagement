using TaskManagement.Core.Models;

namespace TaskManagement.Data.Repositories
{
    public interface ITaskItemRepository
    {
        Task<bool> CreateAsync(TaskItemModel taskItem);
        Task<bool> DeleteAsync(TaskItemModel taskItem);
        Task<TaskItemModel> GetAsync(int id);
        Task<bool> UpdateAsync(TaskItemModel taskItem);
    }
}