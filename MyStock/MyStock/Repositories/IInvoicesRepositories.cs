using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStock.Data;

namespace MyStock.Repositories
{
    interface IInvoicesRepositories
    {
        Invoice GetById(int id);
        IEnumerable<Invoice> GetAll();
        void Add(Invoice invoice);
        void Edit(Invoice invoice);
        void Delete(Invoice invoice);
    }
}
