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
    public partial class VisitantesFrom : Form
    {
        private readonly IVisitantesRepository _visitanteRepo = new VisitanteRepository();
        public VisitantesFrom()
        {
            InitializeComponent();
            CargarVisitantes();
        }

        private void CargarVisitantes()
        {
            dgvVisitantes.DataSource = _visitanteRepo.GetAll();
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
            var visitantes = new Visitante
            {
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                MotivoVisita = txtMotivo.Text
            };
            _visitanteRepo.Añadir(visitantes);
            CargarVisitantes();
            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if(dgvVisitantes.CurrentRow != null)
            {
                var visitantes = new Visitante
                {
                    VisitanteID = (int)dgvVisitantes.CurrentRow.Cells["VisitanteID"].Value,
                    Nombre = txtNombre.Text,
                    Telefono = txtTelefono.Text,
                    MotivoVisita = txtMotivo.Text
                };
                _visitanteRepo.Actualizar(visitantes);
                CargarVisitantes();
                LimpiarCampos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dgvVisitantes.CurrentRow != null)
            {
                int id = (int)dgvVisitantes.CurrentRow.Cells["VisitanteID"].Value;
                _visitanteRepo.Eliminar(id);
                CargarVisitantes();
                LimpiarCampos();
            }
        }

        private void dgvVisitantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvVisitantes.CurrentRow != null)
            {
                txtNombre.Text = dgvVisitantes.CurrentRow.Cells["Nombre"].Value.ToString();
                txtTelefono.Text = dgvVisitantes.CurrentRow.Cells["Telefono"].Value.ToString();
                txtMotivo.Text = dgvVisitantes.CurrentRow.Cells["MotivoVisita"].Value.ToString();
            }
        }
    }
}
