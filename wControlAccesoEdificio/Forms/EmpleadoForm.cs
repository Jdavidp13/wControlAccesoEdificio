using System;
using System.Windows.Forms;
using wControlAccesoEdificio.Entities;
using wControlAccesoEdificio.Data.UnitOfWork;

namespace wControlAccesoEdificio.Forms
{
    public partial class EmpleadoForm : Form
    {
        private readonly UnitOfWork _unitOfWork;

        public EmpleadoForm(UnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;

            cmbRol.Items.AddRange(new[] { "Administrador", "Seguridad", "Empleado" });
            CargarEmpleado();
        }

        private void CargarEmpleado()
        {
            dgvEmpleados.DataSource = _unitOfWork.Empleados.GetAll();
            dgvEmpleados.ClearSelection();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            cmbRol.SelectedIndex = -1;
            txtZona.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var emp = new Empleado
                {
                    Nombre = txtNombre.Text,
                    Rol = cmbRol.Text,
                    ZonaAcceso = int.Parse(txtZona.Text)
                };

                _unitOfWork.Empleados.Add(emp);
                _unitOfWork.SaveChanges();  // en bases de datos reales
                CargarEmpleado();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar empleado: {ex.Message}");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow != null)
            {
                try
                {
                    var emp = new Empleado
                    {
                        EmpleadoID = (int)dgvEmpleados.CurrentRow.Cells["EmpleadoID"].Value,
                        Nombre = txtNombre.Text,
                        Rol = cmbRol.Text,
                        ZonaAcceso = int.Parse(txtZona.Text)
                    };

                    _unitOfWork.Empleados.Update(emp);
                    _unitOfWork.SaveChanges();  // en bases de datos reales
                    CargarEmpleado();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar empleado: {ex.Message}");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow != null)
            {
                try
                {
                    int id = (int)dgvEmpleados.CurrentRow.Cells["EmpleadoID"].Value;
                    _unitOfWork.Empleados.Delete(id);
                    _unitOfWork.SaveChanges();  // en bases de datos reales
                    CargarEmpleado();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar empleado: {ex.Message}");
                }
            }
        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmpleados.CurrentRow != null)
            {
                txtNombre.Text = dgvEmpleados.CurrentRow.Cells["Nombre"].Value.ToString();
                cmbRol.Text = dgvEmpleados.CurrentRow.Cells["Rol"].Value.ToString();
                txtZona.Text = dgvEmpleados.CurrentRow.Cells["ZonaAcceso"].Value.ToString();
            }
        }

        private void EmpleadoForm_Load(object sender, EventArgs e)
        {
            // Aquí podrías cargar otras configuraciones si las necesitas
        }
    }
}
