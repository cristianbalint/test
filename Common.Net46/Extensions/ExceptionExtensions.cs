using Common.Net46.Exceptions;
using Common.Net46.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Net46.Extensions
{
    public static class ExceptionExtensions
    {
        public static ApiResponseModel ToApiResopnseModel(this Exception exception)
        {
            var result = new ApiResponseModel()
            {
                HttpCode = 400,
                Errors = new List<string>() { exception.Message },
                Data = null
            };
            if (exception is DomainValidationException)
            {
                result.Errors = ((DomainValidationException)exception).Errors;
            }
            return result;
        }
    }
}
