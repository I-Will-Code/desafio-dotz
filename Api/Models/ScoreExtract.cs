using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class ScoreExtract
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public String Description { get; set; }

        public long ScoreId { get; set; }
        public virtual Score Score { get; set; }

    }
}
