﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using wControlAccesoEdificio.Data.Repository;
using wControlAccesoEdificio.Data.UnitOfWork;

namespace wControlAccesoEdificio.Forms
{
    public partial class Login : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DB_ControlAccesoEdificio"].ConnectionString;

        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ValidarLogin", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Contraseña", contraseña);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string rol = reader["Rol"].ToString();
                        MessageBox.Show($"Bienvenido, {usuario} ({rol})", "Acceso correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();

                        // Crear repositorios e inyectar UnitOfWork
                        var empleadoRepo = new EmpleadoRepository();
                        var visitanteRepo = new VisitanteRepository();
                        var accesoRepo = new AccesoRepository();
                        var rolRepo = new RolRepository();
                        var unitOfWork = new UnitOfWork(empleadoRepo, visitanteRepo, accesoRepo, rolRepo);

                        Form formulario = null;

                        if (rol == "Administrador")
                        {
                            formulario = new EmpleadoForm(unitOfWork);
                        }
                        else if (rol == "Seguridad")
                        {
                            formulario = new VisitantesForm(unitOfWork);
                        }
                        else
                        {
                            MessageBox.Show("Rol no reconocido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Show();
                            return;
                        }

                        formulario.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    reader.Close();
                }
            }
        }
    }
}
