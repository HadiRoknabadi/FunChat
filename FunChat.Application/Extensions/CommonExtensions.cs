using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.AspNetCore.Identity;

namespace FunChat.Application.Extensions
{
    public static class CommonExtensions
    {
        public static string GetEnumName(this System.Enum myEnum)
        {
            var enumDisplayName = myEnum.GetType().GetMember(myEnum.ToString()).FirstOrDefault();
            if (enumDisplayName != null)
            {
                return enumDisplayName.GetCustomAttribute<DisplayAttribute>()?.GetName();
            }

            return "";
        }

        public static void GetIdentityErrorMessages(this IdentityResult identityResult, List<string> errorMessages)
        {
            var errors = identityResult.Errors.ToList();

            foreach (var error in errors)
            {
                errorMessages.Add(error.Description.Replace("\"", ""));
            }

        }
    }
}
