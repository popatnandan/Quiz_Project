using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using NicePageAdminTheme.Models;
using OfficeOpenXml;

namespace Quiz_Project.Controllers
{
    public class QuizController : Controller
    {
        private IConfiguration configuration;

        public QuizController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult AddEdit()
        {
            return View();
        }


        public IActionResult QuizList()
        {
            string connectionString = this.configuration.GetConnectionString("ConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PR_MST_Quiz_SelectAll";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Load(reader);
                    return View(table);
                }
            }
        }

        public IActionResult QuizDelete(int QuizID)
        {
            try
            {
                string connectionString = configuration.GetConnectionString("ConnectionString");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PR_MST_Quiz_DeleteByPk";
                    command.Parameters.Add("@QuizID", SqlDbType.Int).Value = QuizID;


                    command.ExecuteNonQuery();
                }

                TempData["SuccessMessage"] = "Quiz deleted successfully.";
                return RedirectToAction("QuizList");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while deleting the Quiz: " + ex.Message;
                return RedirectToAction("QuizList");
            }
        }

        [HttpPost]
        public IActionResult QuizAdd(MST_Quiz_Model model)
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
                        command.CommandText = "PR_MST_Quiz_Insert";

                        command.Parameters.AddWithValue("@QuizName", model.QuizName);
                        command.Parameters.AddWithValue("@TotalQuestions", model.TotalQuestions);
                        command.Parameters.AddWithValue("@QuizDate", model.QuizDate);
                        command.Parameters.AddWithValue("@Created", DateTime.Now);
                        command.Parameters.AddWithValue("@Modified", DateTime.Now);
                        command.Parameters.AddWithValue("@UserID", 101);
                        command.ExecuteNonQuery();
                    }
                }
                TempData["SuccessMessage"] = "Quiz added successfully.";
                return RedirectToAction("QuizList");
            }
            return View("AddEdit", model);
        }

        public IActionResult ExportToExcel()
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "PR_MST_Quiz_SelectAll";
                // Note: If your stored procedure requires UserID, uncomment and adjust:
                // sqlCommand.Parameters.Add("@UserID", SqlDbType.Int).Value = 101;

                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    DataTable data = new DataTable();
                    data.Load(sqlDataReader);
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (var package = new ExcelPackage())
                    {
                        var worksheet = package.Workbook.Worksheets.Add("QuizData");

                        // Add headers based on quiz data
                        worksheet.Cells[1, 1].Value = "QuizID";
                        worksheet.Cells[1, 2].Value = "QuizName";
                        worksheet.Cells[1, 3].Value = "TotalQuestions";
                        worksheet.Cells[1, 4].Value = "QuizDate";
                        worksheet.Cells[1, 5].Value = "Created";
                        worksheet.Cells[1, 6].Value = "Modified";

                        // Add data
                        int row = 2;
                        foreach (DataRow item in data.Rows)
                        {
                            worksheet.Cells[row, 1].Value = item["QuizID"];
                            worksheet.Cells[row, 2].Value = item["QuizName"];
                            worksheet.Cells[row, 3].Value = item["TotalQuestions"];
                            worksheet.Cells[row, 4].Value = item["QuizDate"];
                            worksheet.Cells[row, 5].Value = item["Created"];
                            worksheet.Cells[row, 6].Value = item["Modified"];
                            row++;
                        }

                        var stream = new MemoryStream();
                        package.SaveAs(stream);
                        stream.Position = 0;

                        string excelName = $"QuizData-{DateTime.Now:yyyyMMddHHmmss}.xlsx";
                        return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
                    }
                }
            }
        }
    }
}
