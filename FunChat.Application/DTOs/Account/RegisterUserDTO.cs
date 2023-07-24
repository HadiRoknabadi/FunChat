using FluentValidation;

namespace FunChat.Application.DTOs.Account
{
    public class RegisterUserDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class RegisterUserValidator : AbstractValidator<RegisterUserDTO>
    {
        public RegisterUserValidator()
        {
            RuleFor(u => u.FullName).NotNull().WithMessage("لطفا نام و نام خانوادگی خود را وارد کنید")
                .MaximumLength(350).WithMessage("نام و نام خانوادگی نمی تواند بیشتر از 350 کاراکتر باشد");

            RuleFor(u => u.Email).NotNull().WithMessage("لطفا ایمیل خود را وارد کنید")
                .MaximumLength(256).WithMessage("ایمیل نمی تواند بیشتر از 256 کاراکتر باشد")
                .EmailAddress().WithMessage("ایمیل وارد شده معتبر نمی باشد");

            RuleFor(u => u.Password).NotNull().WithMessage("لطفا رمز عبور خود را وارد کنید")
                .MaximumLength(20).WithMessage("رمز عبور نمی تواند بیشتر از 20 کاراکتر باشد")
                .MinimumLength(8).WithMessage("رمز عبور نمی تواند کمتر از 8 کاراکتر باشد");

            RuleFor(u => u.ConfirmPassword).NotNull().WithMessage("لطفا تکرار رمز عبور خود را وارد کنید")
                .MaximumLength(20).WithMessage("تکرار رمز عبور نمی تواند بیشتر از 20 کاراکتر باشد")
                .MinimumLength(8).WithMessage("تکرار رمز عبور نمی تواند کمتر از 8 کاراکتر باشد")
                .Equal(u=>u.Password).WithMessage("رمز های عبور وارد شده مغایرت دارند");
        }
    }




}
