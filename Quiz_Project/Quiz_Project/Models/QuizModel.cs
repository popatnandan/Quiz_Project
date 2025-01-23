using System.ComponentModel.DataAnnotations;

namespace NicePageAdminTheme.Models
{
    public class QuizModel
    {
        public int QuizID { get; set; }
        [Required]

        public string QuizName { get; set; }
        [Required]

        public int TotalQuestions { get; set; }
        [Required]

        public DateTime QuizDate {get; set;}
        [Required]

        public int UserID { get; set; }

        public DateTime Created { get; set; }

        public string Modified { get; set; }
    }
}
