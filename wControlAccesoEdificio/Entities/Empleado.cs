using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wControlAccesoEdificio.Entities
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public int ZonaAcceso { get; set; }
    }
}
