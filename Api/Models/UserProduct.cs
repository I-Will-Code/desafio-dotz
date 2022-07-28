namespace Api.Models
{
    public class UserProduct
    {
        public long UserId { get; set; }
        public virtual User User { get; set; }


        public long ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
