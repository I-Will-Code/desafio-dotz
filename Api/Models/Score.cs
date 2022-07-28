using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Score
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long Total { get; set; }

        public long UserId { get; set; }
        public virtual User? User { get; set; }

        public virtual ICollection<ScoreExtract>? ScoreExtract { get; set; }
    }
}
