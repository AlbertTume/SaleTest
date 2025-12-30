using Microsoft.EntityFrameworkCore;
using SaliTest.Domain.Entities;

namespace SaliTest.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("usuario");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .HasColumnName("userid");

                entity.Property(e => e.Name)
                .HasColumnName("username")
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.Password)
                .HasColumnName("userpassword")
                .IsRequired()
                .HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("productos");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .HasColumnName("productid");

                entity.Property(e => e.Code)
                .HasColumnName("productcode")
                .IsRequired()
                .HasMaxLength(5);

                entity.Property(e => e.Description)
                .HasColumnName("description")
                .HasMaxLength(100)
                .IsRequired();

                entity.Property(e => e.Quantity)
                .HasColumnName("quantity");
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}