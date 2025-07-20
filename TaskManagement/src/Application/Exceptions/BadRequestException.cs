using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace TaskManagement.Application.Exceptions
{
    public class BadRequestException: Exception
    {
        protected BadRequestException(Error[] errors)
            : base(JsonSerializer.Serialize(errors))
        {

        }
    }
}
