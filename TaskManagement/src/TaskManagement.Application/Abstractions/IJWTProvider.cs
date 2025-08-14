using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Users;

namespace TaskManagement.Application.Abstractions
{
    public interface IJWTProvider
    {
        public string GenerateToken(User user);
    }
}
