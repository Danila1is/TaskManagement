using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Teams;

namespace TaskManagement.Domain.Users
{
    public class User
    {
        Guid Guid { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public string? Patronymic { get; set; }

        public DateOnly Birthday { get; set; }

        public required string Email { get; set; } 

        public string? PhoneNumber { get; set; }

        public required string PasswordHash { get; set; }
        public List<Guid> Teams { get; set; } = [];
    }
}
