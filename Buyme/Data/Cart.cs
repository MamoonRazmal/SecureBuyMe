using BuyMe.Components.Data;

namespace BuyMe.Data
{
    public class Cart
    {
        public int Id { get; set; }
       public string? CartOwner{get;set;}
        public List<Product>? CartItem{get;set;}
    }
}