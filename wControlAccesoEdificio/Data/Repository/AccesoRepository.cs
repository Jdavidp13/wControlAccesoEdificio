using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wControlAccesoEdificio.Entities;

namespace wControlAccesoEdificio.Data.Repository
{
    public class AccesoRepository : IAccesoRepository
    {
        private List<Acceso> accesos = new List<Acceso>();

        public void Add(Acceso acceso)
        {
            accesos.Add(acceso);
        }

        public IEnumerable<Acceso> GetAll()
        {
            return accesos;
        }

        public Acceso GetById(int id)
        {
            return accesos.Find(a => a.Id == id);
        }

        public void Update(Acceso acceso)
        {
            var existing = GetById(acceso.Id);
            if (existing != null)
            {
                existing.EmpleadoId = acceso.EmpleadoId;
                existing.VisitanteId = acceso.VisitanteId;
                existing.FechaHora = acceso.FechaHora;
                existing.Zona = acceso.Zona;
                existing.Motivo = acceso.Motivo;
                existing.Autorizado = acceso.Autorizado;
            }
        }

        public void Delete(int id)
        {
            var acceso = GetById(id);
            if (acceso != null)
            {
                accesos.Remove(acceso);
            }
        }
    }
}

