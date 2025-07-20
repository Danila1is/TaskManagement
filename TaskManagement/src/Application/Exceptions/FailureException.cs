using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TaskManagement.Application.Exceptions
{
    public class FailureException: Exception
    {
        protected FailureException(Error[] errors)
            : base(JsonSerializer.Serialize(errors))
        {

        }
    }
}
