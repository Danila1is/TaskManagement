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
    public class StaffRepository : IStaffRepository
    {
        private readonly DataContext _dataContext;

        public StaffRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateAsync(StaffModel staff)
        {
            Staff staffEntity = new Staff
            {
                Id = staff.Id,
                FirstName = staff.FirstName,
                LastName = staff.LastName,
                Patronymic = staff.Patronymic,
                Birthday = staff.Birthday,
                Mail = staff.Mail,
                PhoneNumber = staff.PhoneNumber,
                PasswordHash = staff.PasswordHash,
            };

            await _dataContext.AddAsync(staffEntity);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<StaffModel> GetAsync(int id)
        {
            var staffEntity = await _dataContext.Staffs.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Такого сотрудника нет");

            StaffModel staff = StaffModel.Create(staffEntity.Id, staffEntity.FirstName, staffEntity.LastName, staffEntity.Mail
                , staffEntity.PasswordHash, staffEntity.PhoneNumber, staffEntity.Patronymic, staffEntity.Birthday).staff;

            return staff;
        }

        public async Task<bool> UpdateAsync(StaffModel staff)
        {
            await _dataContext.Staffs.Where(x => x.Id == staff.Id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(f => f.FirstName, f => staff.FirstName)
                .SetProperty(l => l.LastName, l => staff.LastName)
                .SetProperty(p => p.Patronymic, p => staff.Patronymic)
                .SetProperty(b => b.Birthday, b => staff.Birthday)
                .SetProperty(m => m.Mail, m => staff.Mail)
                .SetProperty(p => p.PhoneNumber, p => staff.PhoneNumber)
                .SetProperty(p => p.PasswordHash, p => staff.PasswordHash)
                .SetProperty(p => p.ModifiedDate, p => DateTime.Now));

            return true;
        }

        public async Task<bool> DeleteAsync(StaffModel staff)
        {
            await _dataContext.Staffs.Where(x => x.Id == staff.Id)
                .ExecuteDeleteAsync();

            return true;
        }
    }
}
