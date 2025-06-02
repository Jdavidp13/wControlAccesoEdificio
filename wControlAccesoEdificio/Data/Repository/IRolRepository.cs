using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wControlAccesoEdificio.Entities;

namespace wControlAccesoEdificio.Data.Repository
{
    public interface IRolRepository
    {
        void Add(Rol rol);
        IEnumerable<Rol> GetAll();
        Rol GetById(int id);
        void Update(Rol rol);
        void Delete(int id);
    }
}