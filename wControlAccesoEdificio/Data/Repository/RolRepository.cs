using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wControlAccesoEdificio.Entities;

namespace wControlAccesoEdificio.Data.Repository
{
    public class RolRepository : IRolRepository
    {
        private List<Rol> roles = new List<Rol>();

        public void Add(Rol rol)
        {
            roles.Add(rol);
        }

        public IEnumerable<Rol> GetAll()
        {
            return roles;
        }

        public Rol GetById(int id)
        {
            return roles.Find(r => r.Id == id);
        }

        public void Update(Rol rol)
        {
            var existing = GetById(rol.Id);
            if (existing != null)
            {
                existing.Nombre = rol.Nombre;
                existing.Descripcion = rol.Descripcion;
            }
        }

        public void Delete(int id)
        {
            var rol = GetById(id);
            if (rol != null)
            {
                roles.Remove(rol);
            }
        }
    }
}

