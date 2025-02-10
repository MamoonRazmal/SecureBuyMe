using BuyMe.Components.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Npgsql.Replication;

namespace BuyMe.Data
{
    public class ProduktRepo:IproductRepo
    {
        private readonly IDbContextFactory<ProductContext> dbContextFactory;
        public ProduktRepo(IDbContextFactory<ProductContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        public List<Product> getAllProdukt()
        {
            var db = dbContextFactory.CreateDbContext();
            return db.Products.ToList();
        }
        public void addProdukt(Product produkt)
        {
            var db = dbContextFactory.CreateDbContext();
            db.Products.Add(produkt);
            db.SaveChanges();

        }
        public List<Product> getProductByName(string name)
        {
            var db = dbContextFactory.CreateDbContext();
            return db.Products.Where(p => p.ProductName.Contains(name)).ToList();
        }
        public void deleteProdukt(string name)
        {
            var db = dbContextFactory.CreateDbContext();
            var produkt = db.Products.Where(x=>x.ProductName==name).FirstOrDefault();
            if(produkt is not null)
            {
               db.Products.Remove(produkt); 
               db.SaveChanges();
            }
          
        }
        public void updateProdukt(int id, Product produkt)
        {
            var db = dbContextFactory.CreateDbContext();
            var produktToUpdate = db.Products.Find(id);
            if (produktToUpdate is not null)
            {
                Console.WriteLine($"Before update: {produktToUpdate.ProductName}, {produktToUpdate.Description}");
                produktToUpdate.ProductName = produkt.ProductName;
                produktToUpdate.ProductType = produkt.ProductType;
                produktToUpdate.Description = produkt.Description;
                produktToUpdate.ProductPic  = produkt.ProductPic;
               Console.WriteLine($"After update: {produktToUpdate.ProductName}, {produktToUpdate.Description}");
                db.SaveChanges();
            }
            else
            {
                   Console.WriteLine("produktToUpdate is null");  
            }



        }
        public int GetUpdateProducktId()
        {
            var db = dbContextFactory.CreateDbContext();
            return db.Products.Max(p=>p.ProductId);
        }
        public int getProduktIdByName(string name)
        {
            var db = dbContextFactory.CreateDbContext();
            int number= (db.Products.Where(p => p.ProductName == name).Select(p =>p.ProductId)).FirstOrDefault();
            if(number is not 0)
            {
                      Console.WriteLine("value of "+number);
                        return number;
            }
          
            else return 0;
          
        }
        public List<string>  GetProductsByType()
        {
            var db = dbContextFactory.CreateDbContext();
            var result= db.Products.Select(p => p.ProductType).Distinct().ToList();
            if(result is not null)
            {
                return result;
            }
            else return new List<string>() ;
           


        }
        public List<Product> GetProductByTypeSelected(List<string> proType)
        {
            var db = dbContextFactory.CreateDbContext();
            var result = db.Products.Where(p => proType.Contains(p.ProductType)).ToList();
            if(result is not null)
            {
                return result;
            }
            else return new List<Product>();
        }
    }
}