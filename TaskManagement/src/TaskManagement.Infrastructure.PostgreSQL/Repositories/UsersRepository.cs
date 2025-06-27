using Application.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Users;

namespace TaskManagement.Infrastructure.PostgreSQL.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly PostgresqlDbContext _context;

        public UsersRepository(PostgresqlDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            User? user = await _context.Users
                .Where(x => x.Email == email)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return user;
        }

        public Task<bool> Login(string email, string hashPassword)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
