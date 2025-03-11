using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using NicePageAdminTheme.Models;
using Quiz_Project.Models;

namespace NicePageAdminTheme.Controllers
{

    public class QuestionController : Controller
    {
        private IConfiguration configuration;
        public QuestionController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        //public IActionResult AddEdit()
        //{
        //    return View();
        //}
        public IActionResult AddEdit()
        {
            QuestionLevelDropDown(); // Load dropdown data
            return View(new MST_Question_Model());
        }
        public IActionResult QuestionList()
        {
            string connectionString = this.configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_MST_Question_SelectAll";
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            return View(table);
        }
        public IActionResult QuestionDelete(int QuestionID)
        {
            try
            {
                string connectionString = configuration.GetConnectionString("ConnectionString");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PR_MST_Question_DeleteByPk";
                    command.Parameters.Add("@QuestionID", SqlDbType.Int).Value = QuestionID;


                    command.ExecuteNonQuery();
                }

                TempData["SuccessMessage"] = "Question deleted successfully.";
                return RedirectToAction("QuestionList");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while deleting the Question: " + ex.Message;
                return RedirectToAction("QuestionList");
            }
        }

        public void QuestionLevelDropDown()
        {
            string connectionString = this.configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command2 = connection.CreateCommand();
            command2.CommandType = System.Data.CommandType.StoredProcedure;
            command2.CommandText = "PR_MST_QuestionLevelDropDown";
            SqlDataReader reader2 = command2.ExecuteReader();
            DataTable dataTable2 = new DataTable();
            dataTable2.Load(reader2);
            List<MST_QuestionLevel_DropDown> Question_Level = new List<MST_QuestionLevel_DropDown>();
            foreach (DataRow data in dataTable2.Rows)
            {
                MST_QuestionLevel_DropDown model = new MST_QuestionLevel_DropDown();
                model.QuestionLevelID = Convert.ToInt32(data["QuestionLevelID"]);
                model.QuestionLevelName = data["QuestionLevel"].ToString();
                Question_Level.Add(model);
            }
            ViewBag.Question_Level = Question_Level;
        }

        [HttpPost]
        public IActionResult QuestionAdd(MST_Question_Model model)
        {
            if (ModelState.IsValid)
            {
                string connectionString = configuration.GetConnectionString("ConnectionString");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "PR_MST_Question_Insert";

                        command.Parameters.AddWithValue("@QuestionText", model.QuestionText);
                        command.Parameters.AddWithValue("@OptionA", model.OptionA);
                        command.Parameters.AddWithValue("@OptionB", model.OptionB);
                        command.Parameters.AddWithValue("@OptionC", model.OptionC);
                        command.Parameters.AddWithValue("@OptionD", model.OptionD);
                        command.Parameters.AddWithValue("@CorrectOption", model.CorrectOption);
                        command.Parameters.AddWithValue("@QuestionMarks", model.QuestionMarks);
                        command.Parameters.AddWithValue("@IsActive", model.IsActive);
                        command.Parameters.AddWithValue("@Created", DateTime.Now);
                        command.Parameters.AddWithValue("@Modified", DateTime.Now);
                        command.Parameters.AddWithValue("@UserID", 101);
                        command.Parameters.AddWithValue("@QuestionLevelID", model.QuestionLevelID);
                        command.ExecuteNonQuery();
                    }
                }
                TempData["SuccessMessage"] = "Question added successfully.";
                return RedirectToAction("QuestionList");
            }

            QuestionLevelDropDown(); // Reload dropdown on validation failure
            return View("AddEdit", model);
        }

    }
}
