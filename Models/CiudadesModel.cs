using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using _06Publicaciones.config;
using System.Data.SqlClient;

namespace _06Publicaciones.Models
{
    class CiudadesModel
    {
        public int IdCiudad { get; set; }
        public string Detalle { get; set; }
        public int idPais { get; set; }

        public DataTable todosconrelacion()
        {
            var cadena = "SELECT Ciudades.IdCiudad, Ciudades.Detalle as Ciudad, Paises.IdPais, Paises.Detalle AS 'Pais' FROM Ciudades INNER JOIN Paises ON Ciudades.idPais = Paises.IdPais";
            using (var cn = Conexion.GetConnection())
            {
                try
                {
                    SqlDataAdapter adaptador = new SqlDataAdapter(cadena, cn);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
                catch (SqlException ex)
                {
                    ErrorHandler.ManejarErrorSql(ex, "Error al obtener los datos de las ciudades.");
                }
                catch (Exception ex)
                {
                    ErrorHandler.ManejarErrorGeneral(ex, "Error general al obtener los datos de las ciudades.");
                }
                return null;
            }
        }

        public bool Create(string nombreCiudad, int idPais)
        {
            try
            {
                using (var cn = Conexion.GetConnection())
                {
                    string query = "INSERT INTO Ciudades (Detalle, IdPais) VALUES (@Detalle, @IdPais)";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@Detalle", nombreCiudad);
                        cmd.Parameters.AddWithValue("@IdPais", idPais);

                        
                        if (cn.State != ConnectionState.Open)
                        {
                            cn.Open();
                        }

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (SqlException ex)
            {
                ErrorHandler.ManejarErrorSql(ex, "Error al crear la ciudad.");
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error general al crear la ciudad.");
            }
            return false;
        }

        public bool Update(string id, string nombreCiudad, int idPais)
        {
            try
            {
                using (var cn = Conexion.GetConnection())
                {
                    string query = "UPDATE Ciudades SET Detalle = @Detalle, IdPais = @IdPais WHERE IdCiudad = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Detalle", nombreCiudad);
                        cmd.Parameters.AddWithValue("@IdPais", idPais);

                        
                        if (cn.State != ConnectionState.Open)
                        {
                            cn.Open();
                        }

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (SqlException ex)
            {
                ErrorHandler.ManejarErrorSql(ex, "Error al actualizar la ciudad.");
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error general al actualizar la ciudad.");
            }
            return false;
        }
        public bool Delete(int idCiudad)
        {
            var query = "DELETE FROM Ciudades WHERE IdCiudad = @IdCiudad";
            using (var cn = Conexion.GetConnection())
            {
                try
                {
                    using (var cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@IdCiudad", idCiudad);
                        cn.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0; 
                    }
                }
                catch (SqlException ex)
                {
                    ErrorHandler.ManejarErrorSql(ex, "Error al eliminar la ciudad.");
                }
                catch (Exception ex)
                {
                    ErrorHandler.ManejarErrorGeneral(ex, "Error al eliminar la ciudad.");
                }
                return false;
            }
        }
    }

}