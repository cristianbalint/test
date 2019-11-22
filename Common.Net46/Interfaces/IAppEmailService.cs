using System;
using System.Collections.Generic;

namespace Common.Net46.Interfaces
{
    public interface IAppEmailService
    {
        void SendLocalMail(string toEmail, string subject, string body);
        void SendMail(string toEmail, string subject, string body, string attachmentUrl = null);
        void SendMail(IEnumerable<string> toEmails, string subject, string body, string attachmentUrl = null);
        void SendMail(string toEmail, string subject, string body, List<Tuple<int, string, string>> images);
        void SendMail(string toEmail, string subject, string body, Dictionary<string, string> images);
        void SendMailWithAttach(string toEmail, string subject, string body, byte[] attachmentBytes);
    }
}