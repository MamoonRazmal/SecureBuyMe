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
      public DbSet<CartItem> CartItems{get;set;}
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().
            HasData(new Product { ProductId = 1, ProductName = "Shampoo", ProductType = "Personal", Description = "Used On Hair", ProductPic = "" });

             modelBuilder.Entity<CartItem>()
        .HasOne(ci => ci.Cart)
        .WithMany(c => c.CartItems)  // One Cart can have many CartItems
        .HasForeignKey(ci => ci.CartId);
    
    modelBuilder.Entity<CartItem>()
        .HasOne(ci => ci.Product)
        .WithMany()  // A Product can belong to many CartItems
        .HasForeignKey(ci => ci.ProductId);
        }
    }
}