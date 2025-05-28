using Microsoft.EntityFrameworkCore;
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
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext _dataContext;
        public RoleRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateAsync(RoleModel role)
        {
            Role roleEntity = new Role
            {
                Id = role.Id,
                Name = role.Name,
            };

            await _dataContext.AddAsync(roleEntity);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<RoleModel> GetAsync(int id)
        {
            var roleEntity = await _dataContext.Roles.Where(x => x.Id == id).FirstOrDefaultAsync();

            RoleModel roleModel = RoleModel.Create(roleEntity.Id, roleEntity.Name).role;
            return roleModel;
        }

        public async Task<bool> UpdateAsync(RoleModel role)
        {
            await _dataContext.Roles.Where(x => x.Id == role.Id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(n => n.Name, n => role.Name));

            return true;
        }

        public async Task<bool> DeleteAsync(RoleModel role)
        {
            await _dataContext.Roles.Where(x => x.Id == role.Id)
                .ExecuteDeleteAsync();

            return true;
        }
    }
}
