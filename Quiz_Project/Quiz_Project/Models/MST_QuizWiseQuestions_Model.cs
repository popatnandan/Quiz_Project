using System.ComponentModel.DataAnnotations;

namespace NicePageAdminTheme.Models
{
    public class MST_QuizWiseQuestions_Model
    {
        public int QuizWiseQuestionsID { get; set; }
        [Required]
        public int QuizID { get; set; }
        [Required]
        public int QuestionID { get; set; }
        [Required]
        public int UserID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
