using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Password { get; set; }

        public virtual ICollection<Address>? Addresses { get; set; }

        public virtual ICollection<UserProduct>? UserProducts { get; set; }
    }
}
