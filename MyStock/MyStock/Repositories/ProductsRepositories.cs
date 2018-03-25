using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyStock.Data;
using System.Data.Entity;

namespace MyStock.Repositories
{
    public class ProductsRepositories : IProductsRepositories
    {

        private lannisterEntities db = new lannisterEntities();

        public void Add(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void Delete(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public void Edit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public Product GetById(int id)
        {
            return db.Products.Find(id);
        }
    }
}