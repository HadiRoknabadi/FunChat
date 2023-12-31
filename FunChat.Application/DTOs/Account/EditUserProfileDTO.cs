using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace FunChat.Application.DTOs.Account
{
    public class EditUserProfileDTO
    {
        public int? Id { get; set; }
        public string FullName { get; set; }
        public string UserAvatar { get; set; }
        public IFormFile UserAvatarFile { get; set; }
    }

    public class EditUserProfileValidator:AbstractValidator<EditUserProfileDTO>
    {
        public EditUserProfileValidator()
        {
            RuleFor(u => u.FullName).NotNull().WithMessage("لطفا نام و نام خانوادگی خود را وارد کنید")
                .MaximumLength(350).WithMessage("نام و نام خانوادگی نمی تواند بیشتر از 350 کاراکتر باشد");


        }
    }
}