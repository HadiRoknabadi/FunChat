using FunChat.Application.Services.Interfaces;
using FunChat.WebApplication.PresentationExtensions;
using Microsoft.AspNetCore.Mvc;
using FunChat.Application.DTOs.Common;
using FunChat.Application.DTOs.Account;

namespace FunChat.WebApplication.Areas.User.Controllers
{
    public class AccountController : UserBaseController
    {

        #region Constructor

        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region User Profile

        public async Task<IActionResult> UserProfile()
        {
            var userId=User.GetUserId();
            var userProfileDetails=await _userService.GetUserProfileDetailsForEdit(userId);
            return View(userProfileDetails.Data);
        }


        public async Task<IActionResult> EditUserProfile(EditUserProfileDTO editUserProfileDTO)
        {
            if(ModelState.IsValid)
            {
                var result=await _userService.EditUserProfile(editUserProfileDTO);

                switch(result.Status)
                {
                    case ResultStatus.Success:
                        TempData[SweetAlert_SuccessMessage]=result.StatusMessage;
                        return RedirectToAction(nameof(UserProfile));

                        case ResultStatus.CanNotUploadFile:
                        TempData[SweetAlert_ErrorMessage]=result.StatusMessage;
                        break;
                }
            }


            return View(editUserProfileDTO);
        }

        #endregion

        #region Change User Password

        public IActionResult ChangePassword()
        {
            return View();
        }

        #endregion
    }
}
