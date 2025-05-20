using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wControlAccesoEdificio.Entities;
using System.Data.SqlClient;
using wControlAccesoEdificio.Data.Repository;

namespace wControlAccesoEdificio.Forms
{
    public partial class EmpleadoForm : Form
    {
        private readonly IEmpleadoRepository _empleadoRepo = new EmpleadoRepository();
        public EmpleadoForm()
        {
            InitializeComponent();
            cmbRol.Items.AddRange(new[] { "Administrador", "Seguridad", "Empleado" });
            CargarEmpleado();
        }

        private void CargarEmpleado()
        {
            dgvEmpleados.DataSource = _empleadoRepo.GetAll();
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
            var emp = new Empleado
            {
                Nombre = txtNombre.Text,
                Rol = cmbRol.Text,
                ZonaAcceso = int.Parse(txtZona.Text)
            };
            _empleadoRepo.Actualizar(emp);
            CargarEmpleado();
            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if(dgvEmpleados.CurrentRow != null)
            {
                var emp = new Empleado
                {
                    EmpleadoID = (int)dgvEmpleados.CurrentRow.Cells["EmpleadoID"].Value,
                    Nombre = txtNombre.Text,
                    Rol = cmbRol.Text,
                    ZonaAcceso = int.Parse(txtZona.Text)
                };
                _empleadoRepo.Actualizar(emp);
                CargarEmpleado();
                LimpiarCampos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dgvEmpleados.CurrentRow != null)
            {
                int id = (int)dgvEmpleados.CurrentRow.Cells["EmpleadoID"].Value;
                _empleadoRepo.Eliminar(id);
                CargarEmpleado();
                LimpiarCampos();
            }
        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvEmpleados.CurrentRow != null)
            {
                txtNombre.Text = dgvEmpleados.CurrentRow.Cells["Nombre"].Value.ToString();
                cmbRol.Text = dgvEmpleados.CurrentRow.Cells["Rol"].Value.ToString();
                txtZona.Text = dgvEmpleados.CurrentRow.Cells["ZonaAcceso"].Value.ToString();
            }
        }
    }
}
