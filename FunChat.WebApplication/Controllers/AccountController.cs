using Microsoft.AspNetCore.Mvc;

namespace FunChat.WebApplication.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
