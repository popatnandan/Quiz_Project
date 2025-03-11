using System;
using System.ComponentModel.DataAnnotations;

namespace NicePageAdminTheme.Models
{
    public class MST_Question_Model
    {
        public int QuestionID { get; set; }

        [Required(ErrorMessage = "Question text is required")]
        [StringLength(500, ErrorMessage = "Question text cannot exceed 500 characters")]
        public string QuestionText { get; set; }

        [Required(ErrorMessage = "Question level is required")]
        public int QuestionLevelID { get; set; }

        [Required(ErrorMessage = "Option A is required")]
        [StringLength(200, ErrorMessage = "Option A cannot exceed 200 characters")]
        public string OptionA { get; set; }

        [Required(ErrorMessage = "Option B is required")]
        [StringLength(200, ErrorMessage = "Option B cannot exceed 200 characters")]
        public string OptionB { get; set; }

        [Required(ErrorMessage = "Option C is required")]
        [StringLength(200, ErrorMessage = "Option C cannot exceed 200 characters")]
        public string OptionC { get; set; }

        [Required(ErrorMessage = "Option D is required")]
        [StringLength(200, ErrorMessage = "Option D cannot exceed 200 characters")]
        public string OptionD { get; set; }

        [Required(ErrorMessage = "Correct option is required")]
        [RegularExpression("^[A-D]$", ErrorMessage = "Correct option must be A, B, C, or D")]
        public string CorrectOption { get; set; }

        [Required(ErrorMessage = "Question marks are required")]
        [Range(1, 100, ErrorMessage = "Question marks must be between 1 and 100")]
        public int QuestionMarks { get; set; }

        [Required(ErrorMessage = "Active status is required")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        public int UserID { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

    }
}
