namespace FunChat.Application.Services.Interfaces
{
    public interface ISenderService
    {
        void SendEmail(string to,string subject,string body);
    }
}