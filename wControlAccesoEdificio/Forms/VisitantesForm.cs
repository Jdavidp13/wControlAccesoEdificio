using System;
using System.Linq;
using System.Windows.Forms;
using wControlAccesoEdificio.Entities;
using wControlAccesoEdificio.Data.UnitOfWork;

namespace wControlAccesoEdificio.Forms
{
    public partial class VisitantesForm : Form
    {
        private readonly UnitOfWork _unitOfWork;

        public VisitantesForm(UnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            CargarVisitantes();
        }

        private void CargarVisitantes()
        {
            dgvVisitantes.DataSource = null;
            dgvVisitantes.DataSource = _unitOfWork.Visitantes.GetAll().ToList();
            dgvVisitantes.ClearSelection();
        }

        private void LimpiarCampos()
        {
            txtMotivo.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var visitante = new Visitante
                {
                    VisitanteID = _unitOfWork.Visitantes.GetAll().Count() + 1,  // simulamos autoincremento
                    Nombre = txtNombre.Text,
                    Telefono = txtTelefono.Text,
                    MotivoVisita = txtMotivo.Text
                };

                _unitOfWork.Visitantes.Añadir(visitante);
                _unitOfWork.SaveChanges();
                MessageBox.Show("Visitante agregado correctamente.");
                CargarVisitantes();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar visitante: {ex.Message}");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvVisitantes.CurrentRow != null)
            {
                try
                {
                    var visitante = new Visitante
                    {
                        VisitanteID = (int)dgvVisitantes.CurrentRow.Cells["VisitanteID"].Value,
                        Nombre = txtNombre.Text,
                        Telefono = txtTelefono.Text,
                        MotivoVisita = txtMotivo.Text
                    };

                    _unitOfWork.Visitantes.Actualizar(visitante);
                    _unitOfWork.SaveChanges();
                    MessageBox.Show("Visitante actualizado correctamente.");
                    CargarVisitantes();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar visitante: {ex.Message}");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvVisitantes.CurrentRow != null)
            {
                try
                {
                    int id = (int)dgvVisitantes.CurrentRow.Cells["VisitanteID"].Value;
                    _unitOfWork.Visitantes.Eliminar(id);
                    _unitOfWork.SaveChanges();
                    MessageBox.Show("Visitante eliminado correctamente.");
                    CargarVisitantes();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar visitante: {ex.Message}");
                }
            }
        }

        private void dgvVisitantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVisitantes.CurrentRow != null)
            {
                txtNombre.Text = dgvVisitantes.CurrentRow.Cells["Nombre"].Value.ToString();
                txtTelefono.Text = dgvVisitantes.CurrentRow.Cells["Telefono"].Value.ToString();
                txtMotivo.Text = dgvVisitantes.CurrentRow.Cells["MotivoVisita"].Value.ToString();
            }
        }

        private void VisitantesForm_Load(object sender, EventArgs e)
        {
            // Si necesitas lógica adicional, agrégala aquí.
        }
    }
}
