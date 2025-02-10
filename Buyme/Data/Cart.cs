using BuyMe.Components.Data;
using System.Collections.Generic;

namespace BuyMe.Data
{
    public class Cart
    {
        public int Id { get; set; }
       public string? CartOwner{get;set;}
        public List<CartItem>? CartItems{get;set;}
    }
}