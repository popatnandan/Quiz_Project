using Microsoft.AspNetCore.Mvc;

namespace NicePageAdminTheme.Controllers
{
    public class QuizController : Controller
    {
        public IActionResult AddEdit()
        {
            return View();
        }
        public IActionResult QuizList()
        {
            return View();
        }
        public IActionResult QuizTesing()
        {
            return View();
        }
    }
}
