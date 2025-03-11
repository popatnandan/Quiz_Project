using Microsoft.AspNetCore.Mvc;
using Quiz_Project.Models;
using System.Data.SqlClient;
using System.Data;
using NicePageAdminTheme.Models;

namespace Quiz_Project.Controllers
{
    public class QuestionLevel : Controller
    {
        private IConfiguration configuration;
        public QuestionLevel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult AddQuestionLevelForm()
        {
            return View("AddQuestionLevel");
        }


        [HttpGet]
        public IActionResult AddQuestionLevel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddQuestionLevel(MST_QuestionLevel_Model model)
        {
            if (ModelState.IsValid)
            {
                string connectionString = this.configuration.GetConnectionString("ConnectionString");
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = "PR_MST_QuestionLevel_Insert";
                command.Parameters.AddWithValue("@QuestionLevel", model.QuestionLevelName);
                command.Parameters.AddWithValue("@Created", DateTime.Now);
                command.Parameters.AddWithValue("@Modified", DateTime.Now);
                command.Parameters.AddWithValue("@UserID", 101);
                command.ExecuteNonQuery();
                TempData["SuccessMessageAddedSucessfully"] = "Question Level added successfully.";
                return RedirectToAction("QuestionLevels");
            }

            return View("AddQuestionLevel", model);
        }

        public IActionResult QuestionLevels()
        {
            string connectionString = this.configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_MST_QuestionLevel_SelectAll";
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            return View(table);
        }

        public IActionResult QuestionLevelDelete(int QuestionLevelID)
        {
            try
            {
                string connectionString = configuration.GetConnectionString("ConnectionString");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PR_MST_QuestionLevel_DeleteByPk";
                    command.Parameters.Add("@QuestionLevelID", SqlDbType.Int).Value = QuestionLevelID;


                    command.ExecuteNonQuery();
                }

                TempData["SuccessMessageDelete"] = "Question Level " + QuestionLevelID + " deleted successfully.";
                return RedirectToAction("QuestionLevels");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessageDelete"] = "An error occurred while deleting the Question Level: " + ex.Message;
                return RedirectToAction("QuestionLevels");
            }
        }

    }
}