using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Contracts.Users
{
    public record LoginRequest(string Mail, string password);
}
