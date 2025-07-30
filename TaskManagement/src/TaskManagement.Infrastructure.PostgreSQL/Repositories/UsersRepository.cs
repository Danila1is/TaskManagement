using Application.Users;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Shared;
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

        public async Task<Result<Guid, Failure>> AddAsync(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return Error.Failure("add.error", e.Message).ToFailure();
            }

            return user.Id;
        }

        public async Task<Result<User?, Failure>> GetByEmailAsync(string email)
        {
            try
            {
                User? user = await _context.Users
                    .Where(x => x.Email == email)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                return user;
            }
            catch (Exception e)
            {
                return Error.Failure("get.by.email.error", e.Message).ToFailure();
            }
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
