using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStock.Data;

namespace MyStock.Repositories
{
    interface IPartnersRepositories
    {
        Partner GetById(int id);
        IEnumerable<Partner> GetAll();
        void Add(Partner partner);
        void Edit(Partner partner);
        void Delete(Partner partner);
    }
}
