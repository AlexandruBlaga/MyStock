using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyStock.Data;
using System.Data.Entity;

namespace MyStock.Repositories
{
    public class InvoicesRepositories : IInvoicesRepositories
    {
        private lannisterEntities db = new lannisterEntities();

        public void Add(Invoice invoice)
        {
            db.Invoices.Add(invoice);
            db.SaveChanges();
        }

        public void Delete(Invoice invoice)
        {
            db.Invoices.Remove(invoice);
            db.SaveChanges();
        }

        public void Edit(Invoice invoice)
        {
            db.Entry(invoice).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<Invoice> GetAll()
        {
            var invoices = db.Invoices.Include(i => i.Partner).Include(i => i.Product);
            return invoices.ToList();
        }

        public Invoice GetById(int id)
        {
            return db.Invoices.Find(id);
        }
    }
}