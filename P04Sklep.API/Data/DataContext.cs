using Microsoft.EntityFrameworkCore;
using P05Sklep.Shared;
using P06Sklep.DataSeeder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04Sklep.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product_ProductAdjective>()
                .HasKey(x => new { x.ProductId, x.ProductAdjectiveId });

            //modelBuilder.Entity<Product>().HasData(
            //    new Product()
            //    {
            //        Id = 1,
            //        Title = "product1",
            //        Description = "desc1",
            //        Color = "c1"
            //    },
            //    new Product()
            //    {
            //        Id = 2,
            //        Title = "product2",
            //        Description = "desc2",
            //        Color = "c2"
            //    });

            modelBuilder.Entity<MaterialCategory>().HasData(ProductSeeder.GenerateMaterialCategory());
            modelBuilder.Entity<Product>().HasData(ProductSeeder.GenerateProductData());
            modelBuilder.Entity<ProductAdjective>().HasData(ProductSeeder.GenerateProductAdjective());
            modelBuilder.Entity<Product_ProductAdjective>().HasData(ProductSeeder.GenerateProduct_ProductAdjective());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<MaterialCategory> MaterialCategories { get; set; }
        public DbSet<ProductAdjective> ProductAdjectives { get; set; }
        public DbSet<Product_ProductAdjective> Product_ProductAdjectives { get; set; }


    }
}


/* cały proces
 * dotnet ef => sprawdzamy czy jest zainstalowane dotnet entity framework
 * jak nie jest zainstalowane to polecenie dotnet tool instal --global dotnet-ef
 * dodanie conn string do appsettings.json
 * stworzenie DataContext
 * z program.cs wstrzykujemy connString do DataContext (uwaga potrzebne 3 paczki:
 * -Microsoft.EntityFrameworkCore
 * -Microsoft.EntityFramework.SqlServer
 * -Microsoft.EntityFramework.Design
 * dodanie migracji dotnet ef migrations add InitialMigration
 * aktualizacja bazy danych dotnet ef database update
 */
  
