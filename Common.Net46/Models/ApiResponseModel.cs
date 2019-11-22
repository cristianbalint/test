using Common.Net46.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Common.Net46.Models
{
    public class ApiResponseModel
    {
        public ApiResponseModel()
        {
            HttpCode = 400;
            Errors = new List<string>();
        }

        public ApiResponseModel(object data) : this()
        {
            Data = data;
        }

        public ApiResponseModel(IEnumerable<string> errors) : this()
        {
            HttpCode = 400;
            Errors.AddRange(errors);
        }

        public ApiResponseModel(IEnumerable<string> errors, object data) : this(data)
        {
            HttpCode = 400;
            Errors.AddRange(errors);
        }

        public ApiResponseModel(string error) : this()
        {
            HttpCode = 400;
            Errors.Add(error);
        }

        public ApiResponseModel(string error, object data) : this(data)
        {
            HttpCode = 400;
            Errors.Add(error);
        }

        public ApiResponseModel(int httpCode, string[] errors) : this(errors)
        {
            HttpCode = httpCode;
        }

        public ApiResponseModel(int httpCode, string error) : this(error)
        {
            HttpCode = httpCode;
        }

        public ApiResponseModel(int httpCode, string[] errors, object data) : this(errors, data)
        {
            HttpCode = httpCode;
        }

        public ApiResponseModel(int httpCode, string error, object data) : this(error, data)
        {
            HttpCode = httpCode;
        }

        public ApiResponseModel(IOperationResult result) : this()
        {
            if (result.IsSuccess)
            {
                HttpCode = 200;
                Errors = result.Messages.ToList();
            }
            else
            {
                HttpCode = 400;
                Errors.AddRange(result.Messages);
            }
            Data = result.Data;
        }

        public int HttpCode { get; set; }
        public List<string> Errors { get; set; }
        public object Data { get; set; }
        public bool IsError
        {
            get
            {
                return this.HttpCode >= 400;
            }
        }
    }
}
