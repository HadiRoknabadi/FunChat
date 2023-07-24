using FluentValidation;

namespace FunChat.Application.DTOs.Account
{
    public class LoginUserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }


    public class LoginUserValidator : AbstractValidator<LoginUserDTO>
    {
        public LoginUserValidator()
        {

            RuleFor(u => u.Email).NotNull().WithMessage("لطفا ایمیل خود را وارد کنید")
                .MaximumLength(256).WithMessage("ایمیل نمی تواند بیشتر از 256 کاراکتر باشد")
                .EmailAddress().WithMessage("ایمیل وارد شده معتبر نمی باشد");

            RuleFor(u => u.Password).NotNull().WithMessage("لطفا رمز عبور خود را وارد کنید")
    .MaximumLength(20).WithMessage("رمز عبور نمی تواند بیشتر از 20 کاراکتر باشد")
    .MinimumLength(8).WithMessage("رمز عبور نمی تواند کمتر از 8 کاراکتر باشد");

        }

    }

}
