using FunChat.Application.DTOs.Account;
using FunChat.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FunChat.Application.DTOs.Common;
using System.Text.Json;

namespace FunChat.WebApplication.Controllers
{
    public class AccountController : BaseController
    {

        #region Constructor

        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Register

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDTO registerUserDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUser(registerUserDTO);

                switch (result.Status)
                {
                    case ResultStatus.Success:
                        TempData[SweetAlert_SuccessMessage] = result.StatusMessage;
                        break;

                    case ResultStatus.IdentityError:
                        TempData[SweetAlert_ErrorMessage] = JsonSerializer.Serialize(result.ErrorMessages);
                        break;


                }
            }
            return View(registerUserDTO);
        }

        #endregion

        #region Activate Account

        [Route("[controller]/[action]/{emailActiveCode}")]
        public async Task<IActionResult> ActivateAccount(string emailActiveCode)
        {
            var result = await _userService.ActivateAccount(emailActiveCode);

            switch (result.Status)
            {
                case ResultStatus.Success:
                    TempData[Toast_SuccessMessage] = result.StatusMessage;
                    return RedirectToAction(controllerName: "Home", actionName: "Index");

                case ResultStatus.NotFound:
                    TempData[SweetAlert_WarningMessage] = result.StatusMessage;
                    break;
            }

            return View();
        }

        #endregion

        #region Login

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                TempData[SweetAlert_InfoMessage] = "شما داخل سایت لاگین هستید";
                return RedirectToAction(controllerName: "Home", actionName: "Index");

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDTO loginUserDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginUser(loginUserDTO);

                switch (result.Status)
                {
                    case ResultStatus.Success:
                        TempData[Toast_SuccessMessage] = result.StatusMessage;
                        return RedirectToAction(controllerName: "Home", actionName: "Index");

                    case ResultStatus.AccountNotActivated:
                        TempData[SweetAlert_WarningMessage] = JsonSerializer.Serialize(result.ErrorMessages);
                        break;

                    case ResultStatus.NotFound:
                        TempData[SweetAlert_ErrorMessage] = JsonSerializer.Serialize(result.ErrorMessages);
                        break;
                }
            }

            return View(loginUserDTO);
        }


        #endregion

        #region LogOut User

        public async Task<IActionResult> LogOut()
        {
            var result = await _userService.LogOutUser(User.Identity.IsAuthenticated);

            switch (result.Status)
            {
                case ResultStatus.Success:
                    TempData[Toast_SuccessMessage] = result.StatusMessage;
                    return RedirectToAction(nameof(Login));


                case ResultStatus.UserIsNotAuthenticated:
                    TempData[Toast_WarningMessage] = result.StatusMessage;
                    return RedirectToAction(controllerName: "Home", actionName: "Index");


            }

            return RedirectToAction(nameof(Login));
        }

        #endregion


    }
}
