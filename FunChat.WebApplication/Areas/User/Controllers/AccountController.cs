using Microsoft.AspNetCore.Mvc;

namespace FunChat.WebApplication.Areas.User.Controllers
{
    [Area("User")]
    public class AccountController : Controller
    {
        public IActionResult UserProfile()
        {
            return View();
        }
    }
}
