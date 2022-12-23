using CRUD1.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUD1.Data
{
    public class ProveedorData
    {

        public List<ModelProveedor> Listar()
        {
            var result = new List<ModelProveedor>();
            var connection = new Connection();

            using (var SQLConnection = new SqlConnection(connection.GetSQLInfo()))
            {
                SQLConnection.Open();

                SqlCommand command = new SqlCommand("ListarProveedor", SQLConnection);
                command.CommandType = CommandType.StoredProcedure;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new ModelProveedor()
                        {
                            proveedorID = Convert.ToInt32(reader["proveedorID"]),
                            nombre_prov = reader["nombre_prov"].ToString(),
                            direccion = reader["direccion"].ToString(),
                            cuit = Convert.ToInt32(reader["cuit"]),
                            categoria = reader["categoria"].ToString()
                        });
                    }
                }
            }

            return result;
        }

        public ModelProveedor Obtener(int id)
        {
            var oProveedor = new ModelProveedor();
            var cn = new Connection();

            using (var SQLConnection = new SqlConnection(cn.GetSQLInfo()))
            {
                SQLConnection.Open();

                SqlCommand command = new SqlCommand("ObtenerProveedor", SQLConnection);
                command.Parameters.AddWithValue("proveedorID", id);
                command.CommandType = CommandType.StoredProcedure;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oProveedor.proveedorID = Convert.ToInt32(reader["proveedorID"]);
                        oProveedor.nombre_prov = reader["nombre_prov"].ToString();
                        oProveedor.direccion = reader["direccion"].ToString();
                        oProveedor.cuit = Convert.ToInt32(reader["cuit"]);
                        oProveedor.categoria = reader["categoria"].ToString();
                    }
                }
            }
            return oProveedor;
        }

        public bool Crear(ModelProveedor oProveedor)
        {
            bool result;

            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.GetSQLInfo()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("CrearProveedor", connection);
                    cmd.Parameters.AddWithValue("nombre_prov", oProveedor.nombre_prov);
                    cmd.Parameters.AddWithValue("direccion", oProveedor.direccion);
                    cmd.Parameters.AddWithValue("cuit", oProveedor.cuit);
                    cmd.Parameters.AddWithValue("categoria", oProveedor.categoria);

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

        public bool Editar(ModelProveedor oProveedor)
        {
            bool result;

            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.GetSQLInfo()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("EditarProveedor", connection);
                    cmd.Parameters.AddWithValue("proveedorID", oProveedor.proveedorID);
                    cmd.Parameters.AddWithValue("nombre_prov", oProveedor.nombre_prov);
                    cmd.Parameters.AddWithValue("direccion", oProveedor.direccion);
                    cmd.Parameters.AddWithValue("cuit", oProveedor.cuit);
                    cmd.Parameters.AddWithValue("categoria", oProveedor.categoria);

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

            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.GetSQLInfo()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("EliminarProveedor", connection);
                    cmd.Parameters.AddWithValue("proveedorID", id);
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
    }
}
