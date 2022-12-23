using CRUD1.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUD1.Data
{
    public class UsuariosData
    {

        public List<ModelUsuarios> Listar()
        {
            var result = new List<ModelUsuarios>();
            var connection = new Connection();

            using (var SQLConnection = new SqlConnection(connection.GetSQLInfo()))
            {
                SQLConnection.Open();

                SqlCommand command = new SqlCommand("ListarUsuarios", SQLConnection);
                command.CommandType = CommandType.StoredProcedure;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new ModelUsuarios()
                        {
                            id_usuario = Convert.ToInt32(reader["id_usuario"]),
                            email = reader["email"].ToString(),
                            contraseña = reader["contraseña"].ToString()
                        });
                    }
                }
            }

            return result;
        }

        public ModelUsuarios Obtener(int id)
        {
            var oUsuario = new ModelUsuarios();
            var cn = new Connection();

            using (var SQLConnection = new SqlConnection(cn.GetSQLInfo()))
            {
                SQLConnection.Open();

                SqlCommand command = new SqlCommand("ObtenerUsuario", SQLConnection);
                command.Parameters.AddWithValue("id_usuario", id);
                command.CommandType = CommandType.StoredProcedure;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oUsuario.id_usuario = Convert.ToInt32(reader["id_usuario"]);
                        oUsuario.email = reader["email"].ToString();
                        oUsuario.contraseña = reader["contraseña"].ToString();
                    }
                }
            }
            return oUsuario;
        }

        public bool Crear(ModelUsuarios oUsuario)
        {
            bool result;

            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.GetSQLInfo()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("CrearUsuario", connection);
                    cmd.Parameters.AddWithValue("email", oUsuario.email);
                    cmd.Parameters.AddWithValue("contraseña", oUsuario.contraseña);
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

        public bool Editar(ModelUsuarios oUsuario)
        {
            bool result;

            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.GetSQLInfo()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("EditarUsuario", connection);
                    cmd.Parameters.AddWithValue("id_usuario", oUsuario.id_usuario);
                    cmd.Parameters.AddWithValue("email", oUsuario.email);
                    cmd.Parameters.AddWithValue("contraseña", oUsuario.contraseña);
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
                    SqlCommand cmd = new SqlCommand("EliminarUsuario", connection);
                    cmd.Parameters.AddWithValue("id_usuario", id);
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
