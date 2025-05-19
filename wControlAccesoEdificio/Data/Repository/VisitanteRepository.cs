using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wControlAccesoEdificio.Entities;
using wControlAccesoEdificio.Data.Repository;
using wControlAccesoEdificio.Utils;
using System.Data.SqlClient;


namespace wControlAccesoEdificio.Data.Repository
{
    public class VisitanteRepository : IVisitantesRepository
    {
        private readonly SqlConnection _conn;

        public VisitanteRepository()
        {
            _conn = DBconnection.Instancia.GetSqlConnection();
        }

        public List<Visitante> GetAll()
        {
            var list = new List<Visitante>();
            string query = "SELECT * FROM Visitantes";
            SqlCommand cmd = new SqlCommand(query, _conn);
            _conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Visitante
                {
                    VisitanteID = (int)reader["VisitanteID"],
                    Nombre = reader["Nombre"].ToString(),
                    Telefono = reader["Telefono"].ToString(),
                    MotivoVisita = reader["MotivoVisita"].ToString()
                });
            }
            reader.Close();
            _conn.Close();
            return list;
        }

        public void Añadir(Visitante visitante)
        {
            string query = "INSERT INTO Visitantes (Nombre, Telefono, MotivoVisita) VALUES (@Nombre, @Telefono, @MotivoVisita)";
            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@Nombre", visitante.Nombre);
            cmd.Parameters.AddWithValue("@Telefono", visitante.Telefono);
            cmd.Parameters.AddWithValue("@MotivoVisita", visitante.MotivoVisita);
            _conn.Open();
            cmd.ExecuteNonQuery();
            _conn.Close();
        }

        public void Actualizar(Visitante visitante)
        {
            string query = "UPDATE Visitantes SET Nombre = @Nombre, Telefono = @Telefono, MotivoVisita = @MotivoVisita WHERE VisitanteID = @VisitanteID";
            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@Nombre", visitante.Nombre);
            cmd.Parameters.AddWithValue("@Telefono", visitante.Telefono);
            cmd.Parameters.AddWithValue("@MotivoVisita", visitante.MotivoVisita);
            cmd.Parameters.AddWithValue("@VisitanteID", visitante.VisitanteID);
            _conn.Open();
            cmd.ExecuteNonQuery();
            _conn.Close();
        }

        public void Eliminar(int visitanteId)
        {
            string query = "DELETE FROM Visitantes WHERE VisitanteID = @ID";
            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@ID", visitanteId);
            _conn.Open();
            cmd.ExecuteNonQuery();
            _conn.Close();
        }
    }


}