using Common.Net46.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Common.Net46.Services
{
    public class AppEmailService //: IAppEmailService
    {
        private EmailConfigurations _emailConfigs;

        public AppEmailService(EmailConfigurations configs)
        {
            _emailConfigs = configs;
        }
        //public void SendMail(string toEmail, string subject, string body, string attachmentUrl = null)
        //{
        //    // for a client like gmail or yahoo or outlook the app needs a SSL certificate
        //    using (var smtp = new SmtpClient())
        //    {
        //        var message = new MailMessage();
        //        message.To.Add(new MailAddress(toEmail));  // replace with valid value 
        //        message.From = new MailAddress(_emailConfigs.From);  // replace with valid value
        //        message.Subject = subject;
        //        message.Body = body;
        //        message.IsBodyHtml = true;

        //        Attachment data = null;
        //        if (!string.IsNullOrWhiteSpace(attachmentUrl))
        //        {
        //            // Create the file attachment for this e-mail message.
        //            data = new Attachment(attachmentUrl, MediaTypeNames.Application.Octet);
        //            // Add the file attachment to this e-mail message.
        //            message.Attachments.Add(data);
        //        }
        //        var credential = new NetworkCredential
        //        {
        //            UserName = _emailConfigs.Username,  // replace with valid value
        //            Password = _emailConfigs.Password  // replace with valid value
        //        };
        //        smtp.Credentials = credential;
        //        smtp.Host = _emailConfigs.Host;
        //        smtp.Port = _emailConfigs.Port;
        //        smtp.EnableSsl = _emailConfigs.EnableSsl;
        //        smtp.Send(message);
        //        if (data != null)
        //        {
        //            data.Dispose();
        //        }
        //    }
        //}

        //public void SendMail(IEnumerable<string> toEmails, string subject, string body, string attachmentUrl = null)
        //{
        //    // for a client like gmail or yahoo or outlook the app needs a SSL certificate
        //    using (var smtp = new SmtpClient())
        //    {
        //        var message = new MailMessage();
        //        foreach (var email in toEmails)
        //        {
        //            message.To.Add(new MailAddress(email));
        //        }
        //        message.From = new MailAddress(_emailConfigs.From);
        //        message.Subject = subject;
        //        message.Body = body;
        //        message.IsBodyHtml = true;

        //        Attachment data = null;
        //        if (!string.IsNullOrWhiteSpace(attachmentUrl))
        //        {
        //            // Create the file attachment for this e-mail message.
        //            data = new Attachment(attachmentUrl, MediaTypeNames.Application.Octet);
        //            // Add the file attachment to this e-mail message.
        //            message.Attachments.Add(data);
        //        }
        //        var credential = new NetworkCredential
        //        {
        //            UserName = _emailConfigs.Username,  // replace with valid value
        //            Password = _emailConfigs.Password  // replace with valid value
        //        };
        //        smtp.Credentials = credential;
        //        smtp.Host = _emailConfigs.Host;
        //        smtp.Port = _emailConfigs.Port;
        //        smtp.EnableSsl = _emailConfigs.EnableSsl;
        //        smtp.Send(message);
        //        if (data != null)
        //        {
        //            data.Dispose();
        //        }
        //    }
        //}

        //public void SendMail(string toEmail, string subject, string body, List<Tuple<int, string, string>> images)
        //{
        //    images = images ?? new List<Tuple<int, string, string>>();
        //    // for a client like gmail or yahoo or outlook the app needs a SSL certificate
        //    using (var smtp = new SmtpClient())
        //    {
        //        var message = new MailMessage();
        //        message.To.Add(new MailAddress(toEmail));  // replace with valid value 
        //        message.From = new MailAddress(_emailConfigs.From);  // replace with valid value
        //        message.Subject = subject;
        //        //message.Body = body;
        //        message.IsBodyHtml = true;

        //        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
        //          body, null, "text/html");

        //        foreach (var img in images)
        //        {
        //            LinkedResource LinkedImage = new LinkedResource(img.Item2);
        //            LinkedImage.ContentId = img.Item1.ToString();

        //            //LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);

        //            htmlView.LinkedResources.Add(LinkedImage);
        //        }

        //        message.AlternateViews.Add(htmlView);

        //        var credential = new NetworkCredential
        //        {
        //            UserName = _emailConfigs.Username,  // replace with valid value
        //            Password = _emailConfigs.Password  // replace with valid value
        //        };
        //        smtp.Credentials = credential;
        //        smtp.Host = _emailConfigs.Host;
        //        smtp.Port = _emailConfigs.Port;
        //        smtp.EnableSsl = _emailConfigs.EnableSsl;
        //        smtp.Send(message);
        //    }
        //}

        //public void SendMail(string toEmail, string subject, string body, Dictionary<string, string> images)
        //{
        //    images = images ?? new Dictionary<string, string>();
        //    // for a client like gmail or yahoo or outlook the app needs a SSL certificate
        //    using (var smtp = new SmtpClient())
        //    {
        //        var message = new MailMessage();
        //        message.To.Add(new MailAddress(toEmail));  // replace with valid value 
        //        message.From = new MailAddress(_emailConfigs.From);  // replace with valid value
        //        message.Subject = subject;
        //        //message.Body = body;
        //        message.IsBodyHtml = true;

        //        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
        //          body, null, "text/html");

        //        foreach (var img in images)
        //        {
        //            LinkedResource LinkedImage = new LinkedResource(img.Value);
        //            LinkedImage.ContentId = img.Key.ToString();
        //            LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);
        //            htmlView.LinkedResources.Add(LinkedImage);
        //        }

        //        message.AlternateViews.Add(htmlView);

        //        var credential = new NetworkCredential
        //        {
        //            UserName = _emailConfigs.Username,  // replace with valid value
        //            Password = _emailConfigs.Password  // replace with valid value
        //        };
        //        smtp.Credentials = credential;
        //        smtp.Host = _emailConfigs.Host;
        //        smtp.Port = _emailConfigs.Port;
        //        smtp.EnableSsl = _emailConfigs.EnableSsl;
        //        smtp.Send(message);
        //    }
        //}

        //public void SendMailWithAttach(string toEmail, string subject, string body, byte[] attachmentBytes)
        //{
        //    // for a client like gmail or yahoo or outlook the app needs a SSL certificate
        //    using (var smtp = new SmtpClient())
        //    {
        //        var message = new MailMessage();
        //        message.To.Add(new MailAddress(toEmail));  // replace with valid value 
        //        message.From = new MailAddress(_emailConfigs.From);  // replace with valid value
        //        message.Subject = subject;
        //        message.Body = body;
        //        message.IsBodyHtml = true;

        //        Stream s = null;
        //        if (attachmentBytes.Count() > 0)
        //        {
        //            s = new MemoryStream(attachmentBytes);
        //            // Create the file attachment for this e-mail message.
        //            Attachment data = new Attachment(s, MediaTypeNames.Application.Pdf);
        //            data.Name = "Invoice.pdf";
        //            // Add the file attachment to this e-mail message.
        //            message.Attachments.Add(data);
        //        }

        //        var credential = new NetworkCredential
        //        {
        //            UserName = _emailConfigs.Username,  // replace with valid value
        //            Password = _emailConfigs.Password  // replace with valid value
        //        };
        //        smtp.Credentials = credential;
        //        smtp.Host = _emailConfigs.Host;
        //        smtp.Port = _emailConfigs.Port;
        //        smtp.EnableSsl = _emailConfigs.EnableSsl;
        //        smtp.Send(message);

        //        if (s != null)
        //        {
        //            s.Close();
        //            s.Dispose();
        //        }
        //        message.Dispose();
        //    }
        //}

        //public void SendLocalMail(string toEmail, string subject, string body)
        //{
        //    MailMessage message = new MailMessage("no-reply@amilon.com",
        //                                           toEmail,
        //                                           subject, body);

        //    SmtpClient client = new SmtpClient("localhost");
        //    client.Send(message);
        //}
    }
}
