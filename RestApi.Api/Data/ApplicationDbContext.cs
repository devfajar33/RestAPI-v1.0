using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Api.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace RestApi.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) 
        : base(dbContextOptions)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Prices> Prices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderDetail>SalesOrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Prices>().ToTable("Price");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<SalesOrder>()
                        .ToTable("SalesOrder")
                        .HasMany(s => s.SalesOrderDetails)
                        .WithOne(d => d.SalesOrder)
                        .HasForeignKey(d => d.SalesOrderNo);
            modelBuilder.Entity<SalesOrderDetail>().ToTable("SalesOrderDetail");
        }
    }
}