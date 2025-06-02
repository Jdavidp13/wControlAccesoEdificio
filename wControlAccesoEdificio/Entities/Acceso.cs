using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wControlAccesoEdificio.Entities
{
    public class Acceso
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public int VisitanteId { get; set; }
        public DateTime FechaHora { get; set; }
        public string Zona { get; set; }
        public string Motivo { get; set; }
        public bool Autorizado { get; set; }
    }
}