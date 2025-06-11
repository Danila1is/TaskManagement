using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Contracts.Users
{
    public record UpdateRequest(string FirstName, string LastName, string Patronymic, DateTime Birthday);
}
