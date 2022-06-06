using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.DataStore.SQL
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            // seeding some data
            modelBuilder.Entity<Category>().HasData(
                    new Category { CategoryId = 1, Name = "Sedán", Description = "Vehículos Tipo Sedán 4 Puertas" },
                    new Category { CategoryId = 2, Name = "Pick-Up", Description = "Vehículos Tipo Pick-Up 4X4 y 4X2" },
                    new Category { CategoryId = 3, Name = "Coupé", Description = "Vehículos Tipo Coupé 2 Puertas" }
                );

            modelBuilder.Entity<Product>().HasData(
                    new Product { ProductId = 1, CategoryId = 1, Name = "Nissan Sentra", Quantity = 10, Price = 15000, Year = 2020 },
                    new Product { ProductId = 2, CategoryId = 1, Name = "Toyota Corolla", Quantity = 20, Price = 18000, Year = 2019 },
                    new Product { ProductId = 3, CategoryId = 2, Name = "Nissa NP300", Quantity = 5, Price = 35000, Year = 2021 },
                    new Product { ProductId = 4, CategoryId = 2, Name = "Mitsubishi Sportero", Quantity = 3, Price = 25000, Year = 2018 }
                );
        }
    }
}
