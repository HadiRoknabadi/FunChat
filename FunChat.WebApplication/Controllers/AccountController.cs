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

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDTO registerUserDTO)
        {
            if(ModelState.IsValid)
            {
                var result=await _userService.RegisterUser(registerUserDTO);

                switch(result.Status)
                {
                    case ResultStatus.Success:
                    TempData[SweetAlert_SuccessMessage]=result.StatusMessage;
                    break;

                    case ResultStatus.IdentityError:
                    TempData[SweetAlert_ErrorMessage]=JsonSerializer.Serialize(result.ErrorMessages);
                    break;


                }
            }
            return View(registerUserDTO);
        }
    }
}
