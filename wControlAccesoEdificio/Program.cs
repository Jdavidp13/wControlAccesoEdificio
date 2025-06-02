using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using wControlAccesoEdificio.Data.Repository;
using wControlAccesoEdificio.Data.UnitOfWork;
using wControlAccesoEdificio.Forms;

namespace wControlAccesoEdificio
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Crear repositorios individuales
            var empleadoRepo = new EmpleadoRepository();
            var visitanteRepo = new VisitanteRepository();
            var accesoRepo = new AccesoRepository();
            var rolRepo = new RolRepository();

            // Crear el UnitOfWork con los repositorios
            var unitOfWork = new UnitOfWork(empleadoRepo, visitanteRepo, accesoRepo, rolRepo);

            // Pasar el UnitOfWork al formulario principal
            Application.Run(new EmpleadoForm(unitOfWork));
            Application.Run(new AccesoForm(unitOfWork));

        }
    }
}
