using System;
using System.Data;
using System.Data.SqlClient;

namespace _06Publicaciones.config
{
    public static class Conexion
    {
        private static readonly string connectionString;

        static Conexion()
        {
            // Aquí puedes establecer tu cadena de conexión. Se recomienda obtenerla de un archivo de configuración o variables de entorno.
            connectionString = "Server=DESKTOP-BUUJ9LF\\SQLEXPRESS01;Database=pubs;User Id=sa;Password=erick;";
        }

        public static SqlConnection GetConnection()
        {
            var connection = new SqlConnection(connectionString);
            return connection;
        }

        public static void OpenConnection(SqlConnection connection)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public static void CloseConnection(SqlConnection connection)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
