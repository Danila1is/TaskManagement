using Microsoft.EntityFrameworkCore;
using ModelData.Context;
using ModelData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Core.Models;

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

        public async Task<Boss> GetByIdAsync(int bossId)
        {
            var boss = await _dataContext.Bosses.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == bossId) ?? throw new Exception("Пользователь не найден");

            return boss;
        }

        public async Task<Boss> GetByMailAsync(string bossMail)
        {
            var boss = await _dataContext.Bosses.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Mail == bossMail) ?? throw new Exception("Пользователь не найден");

            return boss;
        }

        public async Task<bool> Update(Boss entity)
        {
            var bossEntity = await _dataContext.Bosses.FirstOrDefaultAsync(x => x.Id == entity.Id)
                ?? throw new Exception("Пользователь не найден");

            _dataContext.Entry(bossEntity).CurrentValues.SetValues(entity);
            _dataContext.SaveChanges();
            return true;
        }

        public async Task<bool> Delete(Boss entity)
        {
            var bossEntity = await _dataContext.Bosses.FirstOrDefaultAsync(x => x.Id == entity.Id)
                ?? throw new Exception("Пользователь не найден");

            _dataContext.Remove(bossEntity);
            _dataContext.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<Staff>> GetStaffsAsync(int bossId)
        {
            var staff = await _dataContext.Staffs.Where(x => x.BossId == bossId)
                .AsNoTracking()
                .ToListAsync();

            return staff;
        }

        public async Task<IEnumerable<ModelData.Model.Task>> GetTasksAsync(int bossId)
        {
            var tasks = await _dataContext.Tasks.Where(x => x.BossId == bossId)
                .AsNoTracking()
                .ToListAsync();

            return tasks;
        }
    }
}
