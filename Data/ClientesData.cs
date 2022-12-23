using CRUD1.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUD1.Data
{
    public class ClientesData
    {

        public List<ModelClientes> Listar()
        {
            var result = new List<ModelClientes>();
            var connection = new Connection();

            using (var SQLConnection = new SqlConnection(connection.GetSQLInfo()))
            {
                SQLConnection.Open();

                SqlCommand command = new SqlCommand("ListarClientes", SQLConnection);
                command.CommandType = CommandType.StoredProcedure;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new ModelClientes()
                        {
                            id_usuario = Convert.ToInt32(reader["id_usuario"]),
                            cuit_dni = Convert.ToInt32(reader["cuit_dni"]),
                            clientes_ID = Convert.ToInt32(reader["clientes_ID"]),
                            nombre_clie = reader["nombre_clie"].ToString(),
                            apellido_clie = reader["apellido_clie"].ToString(),
                            razonsocial_clie = reader["razonsocial_clie"].ToString(),
                            tipo_cliente = reader["tipo_cliente"].ToString()
                        });
                    }
                }
            }

            return result;
        }

        public ModelClientes Obtener(int id)
        {
            var oCliente = new ModelClientes();
            var cn = new Connection();

            using (var SQLConnection = new SqlConnection(cn.GetSQLInfo()))
            {
                SQLConnection.Open();

                SqlCommand command = new SqlCommand("ObtenerCliente", SQLConnection);
                command.Parameters.AddWithValue("clientes_ID", id);
                command.CommandType = CommandType.StoredProcedure;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oCliente.id_usuario = Convert.ToInt32(reader["id_usuario"]);
                        oCliente.cuit_dni = Convert.ToInt32(reader["cuit_dni"]);
                        oCliente.clientes_ID = Convert.ToInt32(reader["clientes_ID"]);
                        oCliente.nombre_clie = reader["nombre_clie"].ToString();
                        oCliente.apellido_clie = reader["apellido_clie"].ToString();
                        oCliente.razonsocial_clie = reader["razonsocial_clie"].ToString();
                        oCliente.tipo_cliente = reader["tipo_cliente"].ToString();
                    }
                }
            }
            return oCliente;
        }

        public bool Crear(ModelClientes oCliente)
        {
            bool result;

            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.GetSQLInfo()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Guardar", connection);
                    cmd.Parameters.AddWithValue("nombre_clie", oCliente.nombre_clie);
                    cmd.Parameters.AddWithValue("apellido_clie", oCliente.apellido_clie);
                    cmd.Parameters.AddWithValue("cuit_dni", oCliente.cuit_dni);
                    cmd.Parameters.AddWithValue("razonsocial_clie", oCliente.razonsocial_clie);
                    cmd.Parameters.AddWithValue("tipo_cliente", oCliente.tipo_cliente);
                    cmd.Parameters.AddWithValue("id_usuario", oCliente.id_usuario);
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

        public bool Editar(ModelClientes oCliente)
        {
            bool result;

            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.GetSQLInfo()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Editar", connection);
                    cmd.Parameters.AddWithValue("clientes_ID", oCliente.clientes_ID);
                    cmd.Parameters.AddWithValue("nombre_clie", oCliente.nombre_clie);
                    cmd.Parameters.AddWithValue("apellido_clie", oCliente.apellido_clie);
                    cmd.Parameters.AddWithValue("cuit_dni", oCliente.cuit_dni);
                    cmd.Parameters.AddWithValue("razonsocial_clie", oCliente.razonsocial_clie);
                    cmd.Parameters.AddWithValue("tipo_cliente", oCliente.tipo_cliente);
                    cmd.Parameters.AddWithValue("id_usuario", oCliente.id_usuario);
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
                    SqlCommand cmd = new SqlCommand("Eliminar", connection);
                    cmd.Parameters.AddWithValue("clientes_ID", id);
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
