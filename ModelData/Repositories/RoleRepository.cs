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
    public class RoleRepository
    {
        private readonly DataContext _dataContext;
        public RoleRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateAsync(Role entity)
        {
            await _dataContext.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Role> GetAsync(int id)
        {
            var role = await _dataContext.Roles.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Такой роли нет");
            return role;
        }

        public async Task<bool> UpdateAsync(Role entity)
        {
            var role = await _dataContext.Roles
                .FirstOrDefaultAsync(x => x.Id == entity.Id) ?? throw new Exception("Такой роли нет");

            _dataContext.Entry(role).CurrentValues.SetValues(entity);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Role entity)
        {
            var role = await _dataContext.Roles
                .FirstOrDefaultAsync(x => x.Id == entity.Id) ?? throw new Exception("Такой роли нет");

            _dataContext.Remove(role);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Staff>> GetStaffByRole(Role roleEntity, Boss bossEntity)
        {
            var role = await _dataContext.Roles.AsNoTracking()
                .Include(x => x.Staffs.Where(x => x.BossId == bossEntity.Id))
                .Where(x => x.Id == roleEntity.Id)
                .FirstOrDefaultAsync() ?? throw new Exception("Нет позиций");

            if (role.Staffs is null)
            {
                throw new Exception("Список сотрудников с данной позицией пуст");
            }

            return role.Staffs;
        }
    }
}
