using System;
using System.ComponentModel.DataAnnotations;

namespace NicePageAdminTheme.Models
{
    public class MST_Quiz_Model
    {
        public int QuizID { get; set; }

        [Required(ErrorMessage = "Quiz name is required.")]
        [StringLength(100, ErrorMessage = "Quiz name cannot exceed 100 characters.")]
        public string QuizName { get; set; }

        [Required(ErrorMessage = "Quiz date is required.")]
        [DataType(DataType.Date)]
        public DateTime QuizDate { get; set; }

        [Required(ErrorMessage = "Total questions are required.")]
        [Range(1, 1000, ErrorMessage = "Total questions must be between 1 and 1000.")]
        public int TotalQuestions { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public int UserID { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
