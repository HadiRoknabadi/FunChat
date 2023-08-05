using Microsoft.AspNetCore.Mvc;

namespace FunChat.WebApplication.Areas.User.Controllers
{
    [Area("User")]
    public class UserBaseController:Controller
    {
         protected string Toast_ErrorMessage = "ToastErrorMessage";
        protected string Toast_SuccessMessage = "ToastSuccessMessage";
        protected string Toast_InfoMessage = "ToastInfoMessage";
        protected string Toast_WarningMessage = "ToastWarningMessage";

        protected string SweetAlert_ErrorMessage = "SweetAlertErrorMessage";
        protected string SweetAlert_SuccessMessage = "SweetAlertSuccessMessage";
        protected string SweetAlert_InfoMessage = "SweetAlertInfoMessage";
        protected string SweetAlert_WarningMessage = "SweetAlertWarningMessage";
    }
}