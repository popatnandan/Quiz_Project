using Microsoft.AspNetCore.Mvc;

namespace NicePageAdminTheme.Controllers
{
    public class QuestionController : Controller
    {
        public IActionResult AddEdit()
        {
            return View();
        }
        public IActionResult QuestionList()
        {
            return View();
        }
    }
}
