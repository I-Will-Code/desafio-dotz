using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class Address
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public long UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
