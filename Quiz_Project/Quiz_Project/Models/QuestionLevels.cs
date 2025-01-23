using System.ComponentModel.DataAnnotations;

namespace NicePageAdminTheme.Models
{
    public class QuestionLevels
    {
        public int QuestionLevelID { get; set; }
        [Required]
        public string QuestionLevel { get; set; }
        [Required]
        public int UserID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
