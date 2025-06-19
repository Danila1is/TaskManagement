using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Contracts.Users
{
    public record RegistrationRequest(string FirstName, string LastName, string Mail, string Password);
}
