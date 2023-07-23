using FunChat.Domain.Entities.Attributes;
using Microsoft.AspNetCore.Identity;

namespace FunChat.Domain.Entities.Account
{
    [Auditable]
    public class Role:IdentityRole<int>
    {

    }
}
