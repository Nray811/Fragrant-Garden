using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using petsFragrant_Test.Models;
using System.Linq;

namespace petsFragrant_Test.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSpec> ProductSpecs { get; set; }
        public DbSet<Spec> Specs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderDetail>(options =>
            {
                options.HasKey(p => new { p.ProdcutId, p.OrderID, p.Amount, p.QtDiscount });
                options.HasOne(p => p.Product).WithMany(p => p.OrderDetails).HasForeignKey(p => p.ProdcutId).OnDelete(DeleteBehavior.Cascade);
                options.HasOne(p => p.Order).WithMany(p => p.Ordertails).HasForeignKey(p => p.OrderID).OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<ProductSpec>(options =>
            {
                options.HasKey(p => new { p.ProdcutId, p.SpecID });
                options.HasOne(p => p.Product).WithMany(p => p.ProductSpecs).HasForeignKey(p => p.ProdcutId).OnDelete(DeleteBehavior.Cascade);
                options.HasOne(p => p.Spec).WithMany(p => p.ProductSpec).HasForeignKey(p => p.SpecID).OnDelete(DeleteBehavior.Cascade);
            });

 
     
        }
    }
}
