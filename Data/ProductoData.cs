using CRUD1.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUD1.Data
{
    public class ProductoData
    {

        public List<ModelProducto> Listar()
        {
            var result = new List<ModelProducto>();
            var connection = new Connection();

            using (var SQLConnection = new SqlConnection(connection.GetSQLInfo()))
            {
                SQLConnection.Open();

                SqlCommand command = new SqlCommand("ListarProducto", SQLConnection);
                command.CommandType = CommandType.StoredProcedure;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new ModelProducto()
                        {
                            productoID = Convert.ToInt32(reader["productoID"]),
                            proveedorID = Convert.ToInt32(reader["proveedorID"]),
                            nom_producto = reader["nom_producto"].ToString(),
                            precio = Convert.ToDecimal(reader["precio"]),
                            stock = Convert.ToInt32(reader["stock"])
                        });
                    }
                }
            }

            return result;
        }

        public ModelProducto Obtener(int id)
        {
            var oProducto = new ModelProducto();
            var cn = new Connection();

            using (var SQLConnection = new SqlConnection(cn.GetSQLInfo()))
            {
                SQLConnection.Open();

                SqlCommand command = new SqlCommand("ObtenerProducto", SQLConnection);
                command.Parameters.AddWithValue("ProductoID", id);
                command.CommandType = CommandType.StoredProcedure;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oProducto.productoID = Convert.ToInt32(reader["productoID"]);
                        oProducto.proveedorID = Convert.ToInt32(reader["proveedorID"]);
                        oProducto.nom_producto = reader["nom_producto"].ToString();
                        oProducto.precio = Convert.ToDecimal(reader["precio"]);
                        oProducto.stock = Convert.ToInt32(reader["stock"]);
                    }
                }
            }
            return oProducto;
        }

        public bool Crear(ModelProducto oProducto)
        {
            bool result;

            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.GetSQLInfo()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("CrearProducto", connection);
                    cmd.Parameters.AddWithValue("proveedorID", oProducto.proveedorID);
                    cmd.Parameters.AddWithValue("nom_producto", oProducto.nom_producto);
                    cmd.Parameters.AddWithValue("precio", oProducto.precio);
                    cmd.Parameters.AddWithValue("stock", oProducto.stock);
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

        public bool Editar(ModelProducto oProducto)
        {
            bool result;

            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.GetSQLInfo()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("EditarProducto", connection);
                    cmd.Parameters.AddWithValue("productoID", oProducto.productoID);
                    cmd.Parameters.AddWithValue("proveedorID", oProducto.proveedorID);
                    cmd.Parameters.AddWithValue("nom_producto", oProducto.nom_producto);
                    cmd.Parameters.AddWithValue("precio", oProducto.precio);
                    cmd.Parameters.AddWithValue("stock", oProducto.stock);

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

        public bool Eliminar(int id)
        {
            bool result;

            // TODO stored procedure should also eliminate Usuarios WHERE id_usuario = @id_usuario

            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.GetSQLInfo()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("EliminarProducto", connection);
                    cmd.Parameters.AddWithValue("productoID", id);
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
