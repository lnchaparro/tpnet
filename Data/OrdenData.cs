using CRUD1.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUD1.Data
{
    public class OrdenData
    {

        public List<ModelOrden> Listar()
        {
            var result = new List<ModelOrden>();
            var connection = new Connection();

            using (var SQLConnection = new SqlConnection(connection.GetSQLInfo()))
            {
                SQLConnection.Open();

                SqlCommand command = new SqlCommand("ListarOrden", SQLConnection);
                command.CommandType = CommandType.StoredProcedure;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new ModelOrden()
                        {
                            ordenID = Convert.ToInt32(reader["ordenID"]),
                            productoID = Convert.ToInt32(reader["productoID"]),
                            clientes_ID = Convert.ToInt32(reader["clientes_ID"]),
                            fecha_generacion = Convert.ToDateTime(reader["fecha_generacion"]),
                            fecha_entrega = Convert.ToDateTime(reader["fecha_entrega"]),
                            empleadosID = Convert.ToInt32(reader["empleadosID"])
                        });
                    }
                }
            }

            return result;
        }

        public ModelOrden Obtener(int id)
        {
            var oOrden = new ModelOrden();
            var cn = new Connection();

            using (var SQLConnection = new SqlConnection(cn.GetSQLInfo()))
            {
                SQLConnection.Open();

                SqlCommand command = new SqlCommand("ObtenerOrden", SQLConnection);
                command.Parameters.AddWithValue("OrdenID", id);
                command.CommandType = CommandType.StoredProcedure;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oOrden.ordenID = Convert.ToInt32(reader["ordenID"]);
                        oOrden.productoID = Convert.ToInt32(reader["productoID"]);
                        oOrden.clientes_ID = Convert.ToInt32(reader["clientes_ID"]);
                        oOrden.fecha_generacion = Convert.ToDateTime(reader["fecha_generacion"]);
                        oOrden.fecha_entrega = Convert.ToDateTime(reader["fecha_entrega"]);
                        oOrden.empleadosID = Convert.ToInt32(reader["empleadosID"]);
                    }
                }
            }
            return oOrden;
        }

        public bool Crear(ModelOrden oOrden)
        {
            bool result;

            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.GetSQLInfo()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("CrearOrden", connection);
                    cmd.Parameters.AddWithValue("productoID", oOrden.productoID);
                    cmd.Parameters.AddWithValue("clientes_ID", oOrden.clientes_ID);
                    cmd.Parameters.AddWithValue("fecha_generacion", oOrden.fecha_generacion);
                    cmd.Parameters.AddWithValue("fecha_entrega", oOrden.fecha_entrega);
                    cmd.Parameters.AddWithValue("empleadosID", oOrden.empleadosID);

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

        public bool Editar(ModelOrden oOrden)
        {
            bool result;

            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.GetSQLInfo()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("EditarOrden", connection);
                    cmd.Parameters.AddWithValue("ordenID", oOrden.ordenID);
                    cmd.Parameters.AddWithValue("productoID", oOrden.productoID);
                    cmd.Parameters.AddWithValue("clientes_ID", oOrden.clientes_ID);
                    cmd.Parameters.AddWithValue("fecha_generacion", oOrden.fecha_generacion);
                    cmd.Parameters.AddWithValue("fecha_entrega", oOrden.fecha_entrega);
                    cmd.Parameters.AddWithValue("empleadosID", oOrden.empleadosID);

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
                    SqlCommand cmd = new SqlCommand("EliminarOrden", connection);
                    cmd.Parameters.AddWithValue("ordenID", id);
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
