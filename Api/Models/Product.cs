using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Product
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public String Description { get; set; }

        public virtual ICollection<UserProduct>? UserProducts { get; set; }
    }
}
