using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Net46.Exceptions
{
    public class DomainValidationException : Exception
    {

        public DomainValidationException()
        {
            Errors = new List<string>();
        }
        public DomainValidationException(string message) : this()
        {
            Errors.Add(message);
        }
        public DomainValidationException(Exception exception) : this()
        {
            Errors.Add(exception.Message);
        }
        public DomainValidationException(string[] messages) : this()
        {
            Errors.AddRange(messages);
        }
        public DomainValidationException(IEnumerable<string> messages) : this()
        {
            Errors.AddRange(messages);
        }

        public void AddError(string message)
        {
            Errors.Add(message);
        }

        public void AddError(string[] messages)
        {
            Errors.AddRange(messages);
        }

        public void AddError(IEnumerable<string> messages)
        {
            Errors.AddRange(messages);
        }

        public void AddError(Exception exception)
        {
            Errors.Add(exception.Message);
        }

        public List<string> Errors { get; private set; }
        public override string Message => string.Join("\n\r", Errors);
        public override string ToString()
        {
            return this.Message;
        }
    }
}
