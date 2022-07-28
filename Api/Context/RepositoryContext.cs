using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Context
{
    public class RepositoryContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Address>? Addresses { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Score>? Scores { get; set; }
        public DbSet<ScoreExtract>? ScoreExtracts { get; set; }
        public DbSet<UserProduct>? UsersProducts { get; set; }

        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProduct>()
                .HasKey(userProduct => new { userProduct.UserId, userProduct.ProductId });
            
            modelBuilder.Entity<UserProduct>()
                .HasOne(up => up.Product)
                .WithMany(p => p.UserProducts)
                .HasForeignKey(up => up.ProductId);
            
            modelBuilder.Entity<UserProduct>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserProducts)
                .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<Order>()
                .Property(o => o.CreatedAt)
                .HasDefaultValue(DateTime.Now);
        }
    }
}