using Common.Net46.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Common.Net46.Services
{
    public class OperationResult : IOperationResult
    {
        public OperationResult()
        {
            // by default operation is with success
            IsSuccess = true;
            Message = "";
            Messages = new List<string>();
        }

        //public OperationResult(IEnumerable<ValidationResult> messages) : this()
        //{
        //    if (messages != null && messages.Count() > 0)
        //    {
        //        // initialize with error
        //        HasNotSucceeded(messages);
        //    }
        //}

        public string Message { get; set; }
        public ICollection<string> Messages { get; set; }
        public bool IsSuccess { get; set; }
        public object Data { get; set; }

        /// <summary>
        /// Set result as not succeded with message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public IOperationResult HasNotSucceeded(string message)
        {
            Message = message;
            Messages.Clear();
            Messages.Add(message);
            IsSuccess = false;
            return this;
        }

        /// <summary>
        /// Set result as not succeded with multiple messages
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public IOperationResult HasNotSucceeded(IEnumerable<string> messages)
        {
            Messages = messages.ToList();
            Message = string.Join(", ", Messages);
            IsSuccess = false;
            return this;
        }

        ///// <summary>
        ///// Set result as not succeded with multiple messages from data annotations
        ///// </summary>
        ///// <param name="message"></param>
        ///// <returns></returns>
        //public IOperationResult HasNotSucceeded(IEnumerable<ValidationResult> results)
        //{
        //    Messages = results.Select(i => i.ErrorMessage).ToList();
        //    Message = string.Join(", ", Messages);
        //    IsSuccess = false;
        //    return this;
        //}

        /// <summary>
        /// Set result as succeded with message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public IOperationResult HasSucceeded(string message)
        {
            Message = message;
            Messages.Clear();
            Messages.Add(message);
            IsSuccess = true;
            return this;
        }
        /// <summary>
        /// Set result as succeded with message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public IOperationResult HasSucceeded(object data, string message = "")
        {
            HasSucceeded(message);
            Data = data;
            return this;
        }

        /// <summary>
        /// Set result as succeded with multiple messages
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public IOperationResult HasSucceeded(IEnumerable<string> messages)
        {
            Message = string.Join(", ", messages);
            Messages = messages.ToList();
            IsSuccess = true;
            return this;
        }

        /// <summary>
        /// Set result as succeded with multiple messages
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public IOperationResult HasSucceeded(object data, IEnumerable<string> messages)
        {
            HasSucceeded(messages);
            Data = data;
            return this;
        }
        
        public static IOperationResult NotSucceeded(string message)
        {
            return new OperationResult().HasNotSucceeded(message);
        }
        public static IOperationResult NotSucceeded(IEnumerable<string> messages)
        {
            return new OperationResult().HasNotSucceeded(messages);
        }
        //public static IOperationResult NotSucceeded(IEnumerable<ValidationResult> messages)
        //{
        //    return new OperationResult().HasNotSucceeded(messages);
        //}

        public static IOperationResult Succeeded(string message = "")
        {
            return new OperationResult().HasSucceeded(message);
        }
        public static IOperationResult Succeeded(IEnumerable<string> messages)
        {
            return new OperationResult().HasSucceeded(messages);
        }

        public static IOperationResult Succeeded(object data, string message = "")
        {
            return new OperationResult().HasSucceeded(data, message);
        }
        public static IOperationResult Succeeded(object data, IEnumerable<string> messages)
        {
            return new OperationResult().HasSucceeded(data, messages);
        }
    }
}
