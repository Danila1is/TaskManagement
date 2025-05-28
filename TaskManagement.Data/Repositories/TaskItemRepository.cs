using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Data.Entities;
using TaskManagement.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Core.Models;

namespace TaskManagement.Data.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly DataContext _dataContext;

        public TaskItemRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateAsync(TaskItemModel taskItem)
        {
            var taskItemEmtity = new TaskItem
            {
                Id = taskItem.Id,
                Description = taskItem.Description,
                Status = taskItem.Status,
                DateStart = taskItem.DateStart,
                DateEnd = taskItem.DateEnd,
                DateDone = taskItem.DateDone,
                Reply = taskItem.Reply,
            };

            return true;
        }

        public async Task<TaskItemModel> GetAsync(int id)
        {
            var entity = await _dataContext.Tasks.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Таких задач нет");

            TaskItemModel taskItem = TaskItemModel.Create(entity.Id, entity.Description, entity.Status, entity.DateStart, entity.DateEnd
                , entity.DateDone, entity.Reply).TaskItemModel;

            return taskItem;
        }

        public async Task<bool> UpdateAsync(TaskItemModel taskItem)
        {
            await _dataContext.Tasks.Where(x => x.Id == taskItem.Id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(d => d.Description, d => taskItem.Description)
                .SetProperty(s => s.Status, s => taskItem.Status)
                .SetProperty(d => d.DateStart, d => taskItem.DateStart)
                .SetProperty(d => d.DateEnd, d => taskItem.DateEnd)
                .SetProperty(d => d.DateDone, d => taskItem.DateDone)
                .SetProperty(d => d.Reply, d => taskItem.Reply));

            return true;
        }

        public async Task<bool> DeleteAsync(TaskItemModel taskItem)
        {
            await _dataContext.Tasks.Where(x => x.Id == taskItem.Id)
                .ExecuteDeleteAsync();

            return true;
        }
    }
}
