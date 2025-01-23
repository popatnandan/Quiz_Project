using System.ComponentModel.DataAnnotations;

namespace NicePageAdminTheme.Models
{
    public class QuestionModel
    {
        public int QuestionID { get; set; }
        [Required]

        public string QuestionText { get; set; }
        [Required]

        public int QuestionLevelID { get; set; }

        public string OptionA { get; set; }
        [Required]
        public string OptionB { get; set; }
        [Required]
        public string OptionC { get; set; }
        [Required]
        public string OptionD { get; set; }
        [Required]
        public string CorrectOption { get; set; }
        [Required]
        public int QuestionMarks { get; set; }
        [Required]

        public bool IsActive { get; set; }
        [Required]

        public int UserID { get; set; }

        public int Created { get; set; }

        public int Modified { get; set; }
    }
}
