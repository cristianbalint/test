using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Net46.Interfaces
{
    public interface IOperationResult
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }
        ICollection<string> Messages { get; set; }
        object Data { get; set; }
        IOperationResult HasNotSucceeded(string message);
        IOperationResult HasNotSucceeded(IEnumerable<string> message);
        //IOperationResult HasNotSucceeded(IEnumerable<ValidationResult> message);
        IOperationResult HasSucceeded(string message);
        IOperationResult HasSucceeded(IEnumerable<string> messages);
    }
}
