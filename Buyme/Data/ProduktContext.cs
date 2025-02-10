using BuyMe.Components.Data;
using Microsoft.EntityFrameworkCore;

namespace BuyMe.Data
{
    public class ProductContext :DbContext
    {
      public ProductContext(DbContextOptions<ProductContext>options) :base(options)
      {

      }
      public DbSet<Product> Products { get; set; }
      public DbSet<Cart> Carts{get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().
            HasData(new Product { ProductId = 1, ProductName = "Shampoo", ProductType = "Personal", Description = "Used On Hair", ProductPic = "" });
        }
    }
}