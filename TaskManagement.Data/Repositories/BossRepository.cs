using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Data.Entities;
using TaskManagement.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Data.Repositories
{
    public class BossRepository 
    {
        private readonly DataContext _dataContext;
        public BossRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateAsync(Boss entity)
        {
            await _dataContext.AddAsync(entity);
            return true;
        }

        public async Task<Boss> GetByIdAsync(int id)
        {
            var boss = await _dataContext.Bosses.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Пользователь не найден");

            return boss;
        }

        public async Task<bool> UpdateAsync(Boss entity)
        {
            var bossEntity = await _dataContext.Bosses.FirstOrDefaultAsync(x => x.Id == entity.Id)
                ?? throw new Exception("Пользователь не найден");

            _dataContext.Entry(bossEntity).CurrentValues.SetValues(entity);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Boss entity)
        {
            var bossEntity = await _dataContext.Bosses.FirstOrDefaultAsync(x => x.Id == entity.Id)
                ?? throw new Exception("Пользователь не найден");

            _dataContext.Remove(bossEntity);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Staff>> GetStaffsAsync(int bossId)
        {
            var staff = await _dataContext.Staffs.Where(x => x.BossId == bossId)
                .AsNoTracking()
                .ToListAsync();

            return staff;
        }

        public async Task<IEnumerable<TaskItem>> GetTasksAsync(int bossId)
        {
            var tasks = await _dataContext.Tasks.Where(x => x.BossId == bossId)
                .AsNoTracking()
                .ToListAsync();

            return tasks;
        }

        public async Task<Boss> GetByMailAsync(string mail)
        {
            var boss = await _dataContext.Bosses.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Mail == mail) ?? throw new Exception("Пользователь не найден");

            return boss;
        }
    }
}
