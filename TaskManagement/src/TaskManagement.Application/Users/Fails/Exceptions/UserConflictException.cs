using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Exceptions;

namespace TaskManagement.Application.Users.Fails.Exceptions
{
    public class UserConflictException: ConflictException
    {
        public UserConflictException(Error[] errors)
            : base(errors)
        {

        }
    }
}
