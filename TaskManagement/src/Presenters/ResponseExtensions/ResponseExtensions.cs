﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace TaskManagement.Presenters.ResponseExtensions
{
    public static class ResponseExtensions
    {
        public static ActionResult ToResponse(this Failure failure)
        {
            if (!failure.Any())
            {
                return new ObjectResult(failure)
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                };
            }

            var distinctErrorTypes = failure
                .Select(x => x.Type)
                .Distinct()
                .ToList();

            int statusCode = distinctErrorTypes.Count > 1
                ? StatusCodes.Status500InternalServerError
                : GetStatusCodeFromErrorType(distinctErrorTypes.First());

            return new ObjectResult(failure)
            {
                StatusCode = statusCode,
            };
        }

        private static int GetStatusCodeFromErrorType(ErrorType errorType)
        {
            return errorType switch
            {
                ErrorType.VALIDATION => StatusCodes.Status400BadRequest,
                ErrorType.NOT_FOUND => StatusCodes.Status404NotFound,
                ErrorType.CONFLICT => StatusCodes.Status409Conflict,
                ErrorType.FAILURE => StatusCodes.Status500InternalServerError,
                _ => StatusCodes.Status500InternalServerError,
            };
        }
    }
}
