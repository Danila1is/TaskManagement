using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared
{
    public record Error
    {
        public string Code { get; }

        public string Message { get; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ErrorType Type { get; }

        public string? InvalidField { get; }

        [JsonConstructor]
        private Error(string code, string message, ErrorType type, string? invalidField = null)
        {
            Code = code;
            Message = message;
            Type = type;
            InvalidField = invalidField;
        }

        public static Error NotFound(string? code, string message, string? invalidField = null)
            => new(code ?? "record.not.found", message, ErrorType.NOT_FOUND, invalidField);

        public static Error Validation(string? code, string message, string? invalidField = null)
            => new(code ?? "validation.is.invalid", message, ErrorType.VALIDATION, invalidField);

        public static Error Failure(string? code, string message, string? invalidField = null)
            => new(code ?? "failure", message, ErrorType.FAILURE, invalidField);

        public static Error Conflict(string? code, string message, string? invalidField = null)
            => new(code ?? "value.is.conflict", message, ErrorType.CONFLICT, invalidField);
    }

    public enum ErrorType
    {
        VALIDATION,
        NOT_FOUND,
        FAILURE,
        CONFLICT
    }
}
