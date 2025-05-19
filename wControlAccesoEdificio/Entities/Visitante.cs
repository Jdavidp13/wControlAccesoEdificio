using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wControlAccesoEdificio.Entities
{
    public class Visitante
    {
        public int VisitanteID { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string MotivoVisita { get; set; }
    }
}
