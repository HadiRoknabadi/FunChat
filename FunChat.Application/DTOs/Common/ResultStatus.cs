using System.ComponentModel.DataAnnotations;

namespace FunChat.Application.DTOs.Common
{
    public enum ResultStatus
    {
        [Display(Name ="عملیات با موفقیت انجام شد")]
        Success,

        [Display(Name = "آیتم مورد نظر یافت نشد")]
        NotFound,

        [Display(Name = "آیتمی با این مشخصات از قبل وجود دارد")]
        ItemIsDuplicate,

        [Display(Name = "ایمیل وارد شده تکراری است")]
        EmailIsExist,

        [Display(Name = "فایل قابل بارگذاری نمی باشد")]
        CanNotUploadFile,

        [Display(Name = "نیاز به وارد شدن به حساب کاربری")]
        UnAuthorized,

        [Display(Name = "خطای ناشناخته")]
        IdentityError,

        [Display(Name = "حساب فعال سازی نشده")]
        AccountNotActivated,

        [Display(Name = "لاگین نیستید")]
        UserIsNotAuthenticated

    }
}
