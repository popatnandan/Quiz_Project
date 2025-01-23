using Microsoft.AspNetCore.Mvc;

namespace NicePageAdminTheme.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult LoginForm()
        {
            return View();
        }
        public IActionResult RegistrationForm()
        {
            return View();
        }
    }
}
