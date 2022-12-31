using CRUD1.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Razor.Language.Extensions;

namespace CRUD1.Data
{
    public class ProductoPromocionData
    {

        public List<ModelProductoPromocion> Listar()
        {
            var result = new List<ModelProductoPromocion>();
            var connection = new Connection();

            using (var SQLConnection = new SqlConnection(connection.GetSQLInfo()))
            {
                SQLConnection.Open();

                SqlCommand command = new SqlCommand("ListarPromocionesProducto", SQLConnection);
                command.CommandType = CommandType.StoredProcedure;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new ModelProductoPromocion()
                        {
                            productoID = Convert.ToInt32(reader["productoID"]),
                            promocionID = Convert.ToInt32(reader["promocionID"]),
                            fecha_inicio = Convert.ToDateTime(reader["fecha_inicio"]),
                            fecha_fin = Convert.ToDateTime(reader["fecha_fin"]),
                        });
                    }
                }
            }

            return result;
        }

        public ModelProductoPromocion Obtener(int producto_id, int promocion_id)
        {
            var oProducto = new ModelProductoPromocion();
            var cn = new Connection();

            using (var SQLConnection = new SqlConnection(cn.GetSQLInfo()))
            {
                SQLConnection.Open();

                SqlCommand command = new SqlCommand("ObtenerPromocionesProducto", SQLConnection);
                command.Parameters.AddWithValue("productoID", producto_id);
                command.Parameters.AddWithValue("promocionID", promocion_id);
                command.CommandType = CommandType.StoredProcedure;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oProducto.productoID = Convert.ToInt32(reader["productoID"]);
                        oProducto.promocionID = Convert.ToInt32(reader["promocionID"]);
                        oProducto.fecha_inicio = Convert.ToDateTime(reader["fecha_inicio"]);
                        oProducto.fecha_fin = Convert.ToDateTime(reader["fecha_fin"]);
                    }
                }
            }
            return oProducto;
        }

        public bool Crear(ModelProductoPromocion oProductoPromocion)
        {
            bool result;

            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.GetSQLInfo()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("CrearPromocionesProducto", connection);
                    cmd.Parameters.AddWithValue("productoID", oProductoPromocion.productoID);
                    cmd.Parameters.AddWithValue("promocionID", oProductoPromocion.promocionID);
                    cmd.Parameters.AddWithValue("fecha_inicio", oProductoPromocion.fecha_inicio);
                    cmd.Parameters.AddWithValue("fecha_fin", oProductoPromocion.fecha_fin);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                result = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;

                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }
            return result;
        }

        public bool Editar(ModelProductoPromocion oProductoPromocion)
        {
            bool result;

            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.GetSQLInfo()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("EditarPromocionesProducto", connection);
                    cmd.Parameters.AddWithValue("productoID", oProductoPromocion.productoID);
                    cmd.Parameters.AddWithValue("promocionID", oProductoPromocion.promocionID);
                    cmd.Parameters.AddWithValue("fecha_inicio", oProductoPromocion.fecha_inicio);
                    cmd.Parameters.AddWithValue("fecha_fin", oProductoPromocion.fecha_fin);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                result = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result = false;
            }
            return result;
        }

        public bool Eliminar(int producto_id, int promocion_id)
        {
            bool result;

            // TODO stored procedure should also eliminate Usuarios WHERE id_usuario = @id_usuario

            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.GetSQLInfo()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("EliminarPromocionesProducto", connection);
                    cmd.Parameters.AddWithValue("productoID", producto_id);
                    cmd.Parameters.AddWithValue("promocionID", promocion_id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                result = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                

                result = false;
            }
            return result;
        }
    }
}
