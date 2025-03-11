using System.ComponentModel.DataAnnotations;

namespace NicePageAdminTheme.Models
{
    public class MST_QuestionLevel_Model
    {
        [Required]
        public int QuestionLevelID { get; set; }
        [Required]
        public string QuestionLevelName { get; set; }
        public int UserID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
