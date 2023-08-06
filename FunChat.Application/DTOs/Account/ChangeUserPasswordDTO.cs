using FluentValidation;

namespace FunChat.Application.DTOs.Account
{
    public class ChangeUserPasswordDTO
    {
        public int UserId { get; set; }
        public string OldPassword { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class ChangeUserPasswordValidator:AbstractValidator<ChangeUserPasswordDTO>
    {
        public ChangeUserPasswordValidator()
        {
            RuleFor(u => u.OldPassword).NotNull().WithMessage("لطفا رمز عبور فعلی خود را وارد کنید")
                .MaximumLength(20).WithMessage("رمز عبور نمی تواند بیشتر از 20 کاراکتر باشد")
                .MinimumLength(8).WithMessage("رمز عبور نمی تواند کمتر از 8 کاراکتر باشد");

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