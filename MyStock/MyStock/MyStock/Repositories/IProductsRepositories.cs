using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStock.Data;

namespace MyStock.Repositories
{
    interface IProductsRepositories
    {
        Product GetById(int id);
        IEnumerable<Product> GetAll();
        void Add(Product product);
        void Edit(Product product);
        void Delete(Product product);
    }
}
