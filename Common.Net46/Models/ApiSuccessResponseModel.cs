using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Net46.Models
{
    public class ApiSuccessResponseModel
    {
        public ApiSuccessResponseModel(object data)
        {
            Data = data;
        }
        public ApiSuccessResponseModel(string message, object data)
        {
            Message = message;
            Data = data;
        }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
