using System.Net.Mail;
using FunChat.Application.Services.Interfaces;

namespace FunChat.Infrastructure.Senders
{
    public class SenderService : ISenderService
    {
        public void SendEmail(string to, string subject, string body)
        {
             MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("hadiroknabadi80@gmail.com", "فان چت");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("hadiroknabadi80@gmail.com", "bivcldgmzaqupfra");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
    }
}