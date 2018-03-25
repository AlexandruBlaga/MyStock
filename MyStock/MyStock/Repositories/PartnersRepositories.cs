using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyStock.Data;
using System.Data.Entity;

namespace MyStock.Repositories
{
    public class PartnersRepositories : IPartnersRepositories
    {
        private lannisterEntities db = new lannisterEntities();

        public void Add(Partner partner)
        {
            db.Partners.Add(partner);
            db.SaveChanges();
        }

        public void Delete(Partner partner)
        {
            db.Partners.Remove(partner);
            db.SaveChanges();
        }

        public void Edit(Partner partner)
        {
            db.Entry(partner).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<Partner> GetAll()
        {
            return db.Partners.ToList();
        }

        public Partner GetById(int id)
        {
            return db.Partners.Find(id);
        }
    }
}