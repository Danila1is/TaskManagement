using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Contracts.Users;
using TaskManagement.Domain.Users;

namespace Application.Users
{
    public interface IUsersRepository
    {
        public Task<Guid> AddAsync(User user);

        public Task<User> GetByEmailAsync(string email);

        public Task<bool> Login(string email, string hashPassword);

        public Task<User> GetById(Guid id);

        public Task<Guid> UpdateAsync(User user);
    }
}
