using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using wControlAccesoEdificio.Data.Repository;
using wControlAccesoEdificio.Utils;
using wControlAccesoEdificio.Entities;

namespace wControlAccesoEdificio.Data.Repository
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly SqlConnection _conn;

        public EmpleadoRepository()
        {
            _conn = DBconnection.Instancia.GetSqlConnection();
        }

        public List<Empleado> GetAll()
        {
            var list = new List<Empleado>();
            string query = "SELECT * FROM Empleados";

            SqlCommand cmd = new SqlCommand(query, _conn);
            _conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Empleado
                {
                    EmpleadoID = (int)reader["EmpleadoID"],
                    Nombre = reader["Nombre"].ToString(),
                    Rol = reader["Rol"].ToString(),
                    ZonaAcceso = (int)(reader["ZonaAcceso"]!=DBNull.Value?(int?)reader["ZonaAcceso"]:null)
                });
            }
            reader.Close();
            _conn.Close();
            return list;
        }

        public void Añadir(Empleado empleado)
        {
            string query = "INSERT INTO Empleados (Nombre, Rol, ZonaAcceso) VALUES (@Nombre, @Rol, @ZonaAcceso)";
            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
            cmd.Parameters.AddWithValue("@Rol", empleado.Rol);
            cmd.Parameters.AddWithValue("@ZonaAcceso", (object)empleado.ZonaAcceso ?? DBNull.Value);
            _conn.Open();
            cmd.ExecuteNonQuery();
            _conn.Close();
        }

        public void Actualizar(Empleado empleado)
        {
            string query = "UPDATE Empleados SET Nombre = @Nombre, Rol = @Rol, ZonaAcceso = @ZonaAcceso WHERE EmpleadoID = @EmpleadoID";
            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
            cmd.Parameters.AddWithValue("@Rol", empleado.Rol);
            cmd.Parameters.AddWithValue("@ZonaAcceso", (object)empleado.ZonaAcceso ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@EmpleadoID", empleado.EmpleadoID);
            _conn.Open();
            cmd.ExecuteNonQuery();
            _conn.Close();
        }

        public void Eliminar(int empleadoId)
        {
            string query = "DELETE FROM Empleados WHERE EmpleadoID = @ID";
            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@ID", empleadoId);
            _conn.Open();
            cmd.ExecuteNonQuery();
            _conn.Close();
        }
    }
}

