using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using wControlAccesoEdificio.Data.Repository;
using wControlAccesoEdificio.Utils;
using wControlAccesoEdificio.Entities;

namespace wControlAccesoEdificio.Data.Repository
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private List<Empleado> empleados = new List<Empleado>();

        public void Add(Empleado empleado)
        {
            empleados.Add(empleado);
        }

        public IEnumerable<Empleado> GetAll()
        {
            return empleados;
        }

        public Empleado GetById(int id)
        {
            return empleados.Find(e => e.EmpleadoID == id);
        }

        public void Update(Empleado empleado)
        {
            var existing = GetById(empleado.EmpleadoID);
            if (existing != null)
            {
                existing.Nombre = empleado.Nombre;
                existing.Rol = empleado.Rol;
                existing.ZonaAcceso = empleado.ZonaAcceso;
            }
        }

        public void Delete(int id)
        {
            var empleado = GetById(id);
            if (empleado != null)
            {
                empleados.Remove(empleado);
            }
        }
    }
}
