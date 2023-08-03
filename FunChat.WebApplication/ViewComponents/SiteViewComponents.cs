using FunChat.Application.Services.Interfaces;
using FunChat.Domain.Entities.Account;
using FunChat.WebApplication.PresentationExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FunChat.WebApplication.ViewComponents
{
    #region Site Header

    public class SiteHeader : ViewComponent
    {
        #region  Constructor

        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;

        public SiteHeader(IUserService userService, UserManager<User> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }



        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var currentUserId = User.GetUserId();

                var user = await _userManager.FindByIdAsync(currentUserId.ToString());

                ViewData["UserFullName"] = user.FullName;

            }

            return View("SiteHeader");

        }

    }

    #endregion
}