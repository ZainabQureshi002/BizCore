using System;
using BizCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BizCore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Products> Products { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure decimal properties with precision and scale
            modelBuilder.Entity<Products>()
                .Property(p => p.SalesPrice)
                .HasColumnType("decimal(18,2)");  // Precision: 18, Scale: 2

            modelBuilder.Entity<Products>()
                .Property(p => p.PurchasePrice)
                .HasColumnType("decimal(18,2)");  // Precision: 18, Scale: 2

            modelBuilder.Entity<Orders>()
                .Property(o => o.TotalOrder)
                .HasColumnType("decimal(18,2)");  // Precision: 18, Scale: 2

            modelBuilder.Entity<OrderItems>()
                .Property(oi => oi.UnitPrice)
                .HasColumnType("decimal(18,2)");  // Precision: 18, Scale: 2

            modelBuilder.Entity<OrderItems>()
                .Property(oi => oi.TotalPrice)
                .HasColumnType("decimal(18,2)");  // Precision: 18, Scale: 2

            // Configure foreign keys for Orders
            //modelBuilder.Entity<Orders>()
            //    .HasOne(o => o.Customer)
            //    .WithMany(c => c.Order)
            //    .HasForeignKey(o => o.Fk_customer)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Orders>()
            //    .HasOne(o => o.Supplier)
            //    .WithMany(s => s.Order)
            //    .HasForeignKey(o => o.Fk_supplier)
            //    .OnDelete(DeleteBehavior.Restrict);

            //// Configure foreign keys for Order_Items
            //modelBuilder.Entity<Order_Items>()
            //    .HasOne(oi => oi.Order)
            //    .WithMany(o => o.OrderItems)
            //    .HasForeignKey(oi => oi.Fk_order)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Order_Items>()
            //    .HasOne(oi => oi.Product)
            //    .WithMany(p => p.OrderItems)
            //    .HasForeignKey(oi => oi.Fk_product)
            //    .OnDelete(DeleteBehavior.Restrict);

            // Data seeding
            modelBuilder.Entity<OrderType>().HasData(
                new OrderType { OrderTypeId = 1, Name = "Purchase" },
                new OrderType { OrderTypeId = 2, Name = "Sale" }
            );
        }
    }
}
