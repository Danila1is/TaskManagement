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
using System.Data;

namespace TaskManagement.Data.Repositories
{
    public class BossRepository : IBossRepository
    {
        private readonly DataContext _dataContext;
        public BossRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateAsync(BossModel boss)
        {
            var bossEntity = new Boss
            {
                Id = boss.Id,
                FirstName = boss.FirstName,
                LastName = boss.LastName,
                Patronymic = boss.Patronymic,
                Birthday = boss.Birthday,
                Mail = boss.Mail,
                PhoneNumber = boss.PhoneNumber,
                PasswordHash = boss.PasswordHash,
            };

            await _dataContext.AddAsync(bossEntity);
            await _dataContext.SaveChangesAsync();

            return true;
        }

        public async Task<BossModel> GetByIdAsync(int id)
        {
            var boss = await _dataContext.Bosses.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Пользователь не найден");

            BossModel bossModel = BossModel.Create(boss.Id, boss.FirstName, boss.LastName, boss.Mail, boss.PasswordHash,
                boss.PhoneNumber, boss.Patronymic, boss.Birthday).boss;

            return bossModel;
        }

        public async Task<bool> UpdateAsync(BossModel boss)
        {
            await _dataContext.Bosses
                .Where(x => x.Id == boss.Id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(f => f.FirstName, f => boss.FirstName)
                .SetProperty(l => l.LastName, l => boss.LastName)
                .SetProperty(p => p.Patronymic, p => boss.Patronymic)
                .SetProperty(b => b.Birthday, b => boss.Birthday)
                .SetProperty(m => m.Mail, m => boss.Mail)
                .SetProperty(p => p.PhoneNumber, p => boss.PhoneNumber)
                .SetProperty(p => p.PasswordHash, p => boss.PasswordHash)
                .SetProperty(p => p.ModifiedDate, p => DateTime.Now));

            return true;
        }

        public async Task<bool> DeleteAsync(BossModel boss)
        {
            await _dataContext.Bosses.Where(x => x.Id == boss.Id)
                .ExecuteDeleteAsync();
            return true;
        }
    }
}
