using Microsoft.AspNetCore.Mvc;

namespace Quiz_Project.Controllers
{
    public class QuizWiseQuestion : Controller
    {
        public IActionResult QuizWiseQuestions()
        {
            return View();
        }
        public IActionResult QuizWiseQuestionDetails()
        {
            return View();
        }
        public IActionResult AddQuizWiseQuestions()
        {
            return View();
        }
    }
}
