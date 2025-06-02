using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wControlAccesoEdificio.Entities;

namespace wControlAccesoEdificio.Data.Repository
{
    public interface IAccesoRepository
    {
        void Add(Acceso acceso);
        IEnumerable<Acceso> GetAll();
        Acceso GetById(int id);
        void Update(Acceso acceso);
        void Delete(int id);
    }
}
