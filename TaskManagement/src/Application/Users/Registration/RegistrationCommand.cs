using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Contracts.Users;

namespace TaskManagement.Application.Users.Registration
{
    public record RegistrationCommand(RegistrationRequest registrationRequest);
}
