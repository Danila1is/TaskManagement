using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Extensions
{
    public static class ValidationExtensions
    {
        public static Failure ToErrors(this FluentValidation.Results.ValidationResult validationResult)
        {
            return validationResult.Errors.Select(e => Error.Validation(e.ErrorCode, e.ErrorMessage, e.PropertyName)).ToArray();
        }
    }
}
