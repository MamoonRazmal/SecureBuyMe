using BuyMe.Components.Data;
using BuyMe.Data;

public interface IproductRepo
{
    public List<Product> getAllProdukt();
    public void addProdukt(Product produkt);
    public void deleteProdukt(string id);
    public List<Product> getProductByName(string name);
    public void updateProdukt(int id, Product produkt);
    public int GetUpdateProducktId();
    public int getProduktIdByName(string name);
    public List<string> GetProductsByType();
    public List<Product> GetProductByTypeSelected(List<string> proType);

    public void AddToCart(List<Product> productsList,string userName);
     public Cart  GetCart();
     public void RemoveCart(int id);
}