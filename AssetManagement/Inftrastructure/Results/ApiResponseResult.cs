using Common.Net46.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace AssetManagement.Inftrastructure.Results
{
    public class ApiResponseResult : IHttpActionResult
    {
        public ApiResponseResult()
        {
            Data = null;
            HttpCode = 200;
            Messages = new List<string>();
        }

        public ApiResponseResult(object data) : this()
        {
            Data = data;
        }

        public ApiResponseResult(IEnumerable<string> messages) : this()
        {
            HttpCode = 400;
            Messages.AddRange(messages);
        }

        public ApiResponseResult(IEnumerable<string> messages, object data) : this(data)
        {
            HttpCode = 400;
            Messages.AddRange(messages);
        }

        public ApiResponseResult(string message) : this()
        {
            HttpCode = 400;
            Messages.Add(message);
        }

        public ApiResponseResult(string message, object data) : this(data)
        {
            HttpCode = 400;
            Messages.Add(message);
        }

        public ApiResponseResult(int httpCode, string[] messages) : this(messages)
        {
            HttpCode = httpCode;
        }

        public ApiResponseResult(int httpCode, string message) : this(message)
        {
            HttpCode = httpCode;
        }

        public ApiResponseResult(int httpCode, string[] messages, object data) : this(messages, data)
        {
            HttpCode = httpCode;
        }

        public ApiResponseResult(int httpCode, string message, object data) : this(message, data)
        {
            HttpCode = httpCode;
        }

        public ApiResponseResult(IOperationResult result) : this()
        {
            if (result.IsSuccess)
            {
                HttpCode = 200;
                Messages = result.Messages.ToList();
            }
            else
            {
                HttpCode = 400;
                Messages.AddRange(result.Messages);
            }
            Data = result.Data;
        }

        public int AppErrorCode { get; set; }
        public int HttpCode { get; set; }
        public List<string> Messages { get; set; }
        public object Data { get; set; }
        
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(this))
            };
            return Task.FromResult(response);
        }
    }
}