using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace wControlAccesoEdificio.Utils
{
    public sealed class DBconnection
    {
        private static readonly DBconnection instancia = new DBconnection();
        private readonly SqlConnection connection;
        private DBconnection()
        {
            string connSr = ConfigurationManager.ConnectionStrings["DB_ControlAccesoEdificio"].ConnectionString;
            connection = new SqlConnection(connSr);
        }
        public static DBconnection Instancia => instancia;
        public SqlConnection GetSqlConnection()
        {
            return connection; 
        }
    }
}
