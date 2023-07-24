using FunChat.Domain.Entities.Attributes;
using Microsoft.AspNetCore.Identity;

namespace FunChat.Domain.Entities.Account
{
    [Auditable]
    public class User:IdentityUser<int>
    {
        public string FullName { get; set; }
        public string EmailActiveCode { get; set; }
        public string UserAvatar { get; set; }
    }
}
