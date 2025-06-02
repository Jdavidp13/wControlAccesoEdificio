using System;
using System.Linq;
using System.Windows.Forms;
using wControlAccesoEdificio.Entities;
using wControlAccesoEdificio.Data.UnitOfWork;

namespace wControlAccesoEdificio.Forms
{
    public partial class AccesoForm : Form
    {
        private readonly UnitOfWork _unitOfWork;

        public AccesoForm(UnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            CargarAccesos();
        }

        private void CargarAccesos()
        {
            dgvAccesos.DataSource = null;
            dgvAccesos.DataSource = _unitOfWork.Accesos.GetAll().ToList();
            dgvAccesos.ClearSelection();
        }

        private void LimpiarCampos()
        {
            txtEmpleadoId.Clear();
            txtVisitanteId.Clear();
            txtZona.Clear();
            txtMotivo.Clear();
            chkAutorizado.Checked = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var acceso = new Acceso
                {
                    Id = _unitOfWork.Accesos.GetAll().Count() + 1,  // simulamos autoincremento
                    EmpleadoId = int.Parse(txtEmpleadoId.Text),
                    VisitanteId = int.Parse(txtVisitanteId.Text),
                    FechaHora = DateTime.Now,
                    Zona = txtZona.Text,
                    Motivo = txtMotivo.Text,
                    Autorizado = chkAutorizado.Checked
                };

                _unitOfWork.Accesos.Add(acceso);
                _unitOfWork.SaveChanges();
                MessageBox.Show("Acceso registrado correctamente.");
                CargarAccesos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar acceso: {ex.Message}");
            }
        }

        private void dgvAccesos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAccesos.CurrentRow != null)
            {
                txtEmpleadoId.Text = dgvAccesos.CurrentRow.Cells["EmpleadoId"].Value.ToString();
                txtVisitanteId.Text = dgvAccesos.CurrentRow.Cells["VisitanteId"].Value.ToString();
                txtZona.Text = dgvAccesos.CurrentRow.Cells["Zona"].Value.ToString();
                txtMotivo.Text = dgvAccesos.CurrentRow.Cells["Motivo"].Value.ToString();
                chkAutorizado.Checked = (bool)dgvAccesos.CurrentRow.Cells["Autorizado"].Value;
            }
        }

        private void AccesoForm_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void txtZona_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtMotivo_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {

        }

        private void dgvAccesos_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
