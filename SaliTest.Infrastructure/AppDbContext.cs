using Microsoft.EntityFrameworkCore;
using SaliTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaliTest.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Users { get; set; }
        public DbSet<Producto> Productos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .HasColumnName("userID");

                entity.Property(e => e.Name)
                .HasColumnName("userName")
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.Password)
                .HasColumnName("userPassword")
                .IsRequired()
                .HasMaxLength(50);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .HasColumnName("productoID");

                entity.Property(e => e.Code)
                .HasColumnName("productCode")
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
