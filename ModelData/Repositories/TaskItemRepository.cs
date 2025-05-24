using Microsoft.EntityFrameworkCore;
using ModelData.Context;
using ModelData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Data.Repositories
{
    public class TaskItemRepository
    {
        private readonly DataContext _dataContext;

        public TaskItemRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateAsync(TaskItem entity)
        {
            await _dataContext.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<TaskItem> GetAsync(int id)
        {
            var taskItem = await _dataContext.Tasks.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Таких задач нет");
            return taskItem;
        }

        public async Task<bool> UpdateAsync(TaskItem entity)
        {
            var taskItem = await _dataContext.Tasks
                .FirstOrDefaultAsync(x => x.Id == entity.Id) ?? throw new Exception("Таких задач нет");

            _dataContext.Entry(taskItem).CurrentValues.SetValues(entity);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(TaskItem entity)
        {
            var task = await _dataContext.Tasks
                .FirstOrDefaultAsync(x => x.Id == entity.Id) ?? throw new Exception("Такой задачи нет");

            _dataContext.Remove(task);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boss> GetBoss(TaskItem entity)
        {
            var boss = await _dataContext.Bosses.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == entity.BossId) ?? throw new Exception("Такого пользователя нет");
            
            return boss;
        }

        public async Task<Staff> GetStaff(TaskItem entity)
        {
            var staff = await _dataContext.Staffs.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == entity.StaffId) ?? throw new Exception("Такого сотрудника нет");

            return staff;
        }
    }
}
