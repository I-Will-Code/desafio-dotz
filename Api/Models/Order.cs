using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Order
    {
        [Key]
        public long Id { get; set; }

        public bool Delivered { get; set; }

        public DateTime CreatedAt { get; set; }

        public long UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
