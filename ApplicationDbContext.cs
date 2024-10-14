global using Microsoft.EntityFrameworkCore;
using ProductCategory.Models;
using System.Collections.Generic;
using System.Reflection.Emit;


namespace ProductCategory
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                .IsRequired();

            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name)
                .IsRequired();

                entity.HasOne(e => e.Category)
                .WithMany()
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Category")
                .IsRequired();


            });
        }
    }

}
