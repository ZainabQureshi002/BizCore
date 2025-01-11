using System;
using BizCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BizCore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure decimal properties with precision and scale
            modelBuilder.Entity<Product>()
                .Property(p => p.SalesPrice)
                .HasColumnType("decimal(18,2)");  // Precision: 18, Scale: 2

       

      // Precision: 18, Scale: 2

            

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.TotalPrice)
                .HasColumnType("decimal(18,2)");
            // Precision: 18, Scale: 2
            modelBuilder.Entity<OrderItem>()
               .Ignore(o => o.TotalPrice);

            


        }
    }
}
