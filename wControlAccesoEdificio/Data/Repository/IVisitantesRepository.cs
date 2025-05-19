using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wControlAccesoEdificio.Entities;

namespace wControlAccesoEdificio.Data.Repository
{
    public interface IVisitantesRepository
    {
        List<Visitante> GetAll();
        void Añadir(Visitante visitante);
        void Actualizar(Visitante visitante);
        void Eliminar(int visitanteID);
    }
}
