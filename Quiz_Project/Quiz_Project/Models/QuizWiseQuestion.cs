using System.ComponentModel.DataAnnotations;

namespace NicePageAdminTheme.Models
{
    public class QuizWiseQuestion
    {
        public int QuizWiseQuestionsID { get; set; }
        [Required]
        public int QuizID { get; set; }

        public int QuestionID { get; set; }
        public int UserID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
