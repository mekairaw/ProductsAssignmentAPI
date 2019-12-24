using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsAssignmentAPI.Domain.Models;

namespace ProductsAssignmentAPI.Domain.Persistence.Contexts
{
    public class AppDbContext: DbContext
    {
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Propertyes for ProductType
            modelBuilder.Entity<ProductType>().ToTable("ProductType");
            modelBuilder.Entity<ProductType>().HasKey(t => t.Id);
            modelBuilder.Entity<ProductType>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<ProductType>().Property(t => t.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<ProductType>().HasMany(t => t.Products).WithOne(p => p.ProductType).HasForeignKey(p => p.ProductTypeId);

            modelBuilder.Entity<ProductType>().HasData(
                new ProductType { Id = 1, Name = "StandAlone" },
                new ProductType { Id = 2, Name = "Bundle" });


            //Properties for Product
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(p => p.IsActive).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Notes).HasColumnType("text");
            modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
        }
    }
}
