using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wControlAccesoEdificio.Entities;

namespace wControlAccesoEdificio.Data.Repository
{
    public interface IEmpleadoRepository
    {
        List<Empleado> GetAll();
        void Añadir(Empleado empleado);
        void Actualizar(Empleado empleado);
        void Eliminar(int empleadoID);
    }
}
