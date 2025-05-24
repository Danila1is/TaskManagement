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
    public class StaffRepository
    {
        private readonly DataContext _dataContext;

        public StaffRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateAsync(Staff entity)
        {
            await _dataContext.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Staff> GetAsync(int id)
        {
            var staff = await _dataContext.Staffs.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Такого сотрудника нет");
            return staff;
        }

        public async Task<bool> UpdateAsync(Staff entity)
        {
            var staff = await _dataContext.Staffs
                .FirstOrDefaultAsync(x => x.Id == entity.Id) ?? throw new Exception("Такого сотрудника нет");

            _dataContext.Entry(staff).CurrentValues.SetValues(entity);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Staff entity)
        {
            var staff = await _dataContext.Staffs
                .FirstOrDefaultAsync(x => x.Id == entity.Id) ?? throw new Exception("Такого сотрудника нет");

            _dataContext.Remove(staff);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boss> GetBossAsync(Staff entity)
        {
            var boss = await _dataContext.Bosses.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == entity.BossId) ?? throw new Exception("Такого пользователя нет");

            return boss;
        }
    }
}
