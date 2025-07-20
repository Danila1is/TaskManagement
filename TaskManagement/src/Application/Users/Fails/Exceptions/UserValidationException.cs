using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Exceptions;

namespace TaskManagement.Application.Users.Fails.Exceptions
{
    public class UserValidationException: BadRequestException
    {
        public UserValidationException(Error[] errors)
            : base(errors)
        {

        }
    }
}
