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

            //System.Net.Mail.Attachment attachment;
            // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
            // mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("hadiroknabadi80@gmail.com", "HONEY1382264618412135");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
    }
}