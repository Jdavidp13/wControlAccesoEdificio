using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wControlAccesoEdificio.Data.Repository;

namespace wControlAccesoEdificio.Data.UnitOfWork
{
    public class UnitOfWork
    {
        public IEmpleadoRepository Empleados { get; }
        public IVisitantesRepository Visitantes { get; }
        public IAccesoRepository Accesos { get; }
        public IRolRepository Roles { get; }

        public UnitOfWork(
            IEmpleadoRepository empleadoRepository,
            IVisitantesRepository visitantesRepository,
            IAccesoRepository accesoRepository,
            IRolRepository rolRepository)
        {
            Empleados = empleadoRepository;
            Visitantes = visitantesRepository;
            Accesos = accesoRepository;
            Roles = rolRepository;
        }

        public void SaveChanges()
        {
        }
    }
}
