using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using wControlAccesoEdificio.Data.UnitOfWork;
using wControlAccesoEdificio.Entities;

namespace wControlAccesoEdificio.Forms
{
    public partial class ReportesForm : Form
    {
        private readonly UnitOfWork _unitOfWork;

        public ReportesForm(UnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            CargarDatosIniciales();
        }

        private void CargarDatosIniciales()
        {
            // Cargar combo de zonas disponibles (opcional)
            var zonas = _unitOfWork.Accesos.GetAll()
                .Select(a => a.Zona)
                .Distinct()
                .ToList();
            cmbZona.DataSource = zonas;
            cmbZona.SelectedIndex = -1;

            // Inicializa el filtro de fecha con la fecha actual
            dtpFecha.Value = DateTime.Now;
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener todos los accesos
                IEnumerable<Acceso> accesos = _unitOfWork.Accesos.GetAll();

                // Filtrar por persona (Empleado o Visitante)
                if (!string.IsNullOrWhiteSpace(txtPersona.Text))
                {
                    string personaFiltro = txtPersona.Text.ToLower();
                    accesos = accesos.Where(a =>
                        _unitOfWork.Empleados.GetAll().Any(emp => emp.EmpleadoID == a.EmpleadoId && emp.Nombre.ToLower().Contains(personaFiltro)) ||
                        _unitOfWork.Visitantes.GetAll().Any(vis => vis.VisitanteID == a.VisitanteId && vis.Nombre.ToLower().Contains(personaFiltro)));
                }

                // Filtrar por zona
                if (cmbZona.SelectedItem != null)
                {
                    string zonaFiltro = cmbZona.SelectedItem.ToString();
                    accesos = accesos.Where(a => a.Zona == zonaFiltro);
                }

                // Filtrar por fecha
                DateTime fechaFiltro = dtpFecha.Value.Date;
                accesos = accesos.Where(a => a.FechaHora.Date == fechaFiltro);

                // Mostrar resultados en el DataGridView
                dgvReporte.DataSource = accesos.ToList();
                dgvReporte.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar reporte: {ex.Message}");
            }
        }

        private void ReportesForm_Load(object sender, EventArgs e)
        {
        }
    }
}
