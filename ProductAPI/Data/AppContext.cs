using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Data
{
    public class AppContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public AppContext(DbContextOptions<AppContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.Name).HasMaxLength(80);
            modelBuilder.Entity<Product>().Property(x => x.Price).HasPrecision(10, 2);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "PC", Price = 345.45m },
                new Product { Id = 2, Name = "Note", Price = 312.3m },
                new Product { Id = 3, Name = "Laptop", Price = 231m });

            base.OnModelCreating(modelBuilder);
        }

    }
}
