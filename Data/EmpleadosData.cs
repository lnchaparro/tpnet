using CRUD1.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUD1.Data
{
    public class EmpleadosData
    {

        public List<ModelEmpleados> Listar()
        {
            var result = new List<ModelEmpleados>();
            var connection = new Connection();

            using (var SQLConnection = new SqlConnection(connection.GetSQLInfo()))
            {
                SQLConnection.Open();

                SqlCommand command = new SqlCommand("ListarEmpleados", SQLConnection);
                command.CommandType = CommandType.StoredProcedure;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new ModelEmpleados()
                        {
                            empleadosID = Convert.ToInt32(reader["empleadosID"]),
                            nombre_emp = reader["nombre_emp"].ToString(),
                            apellido_emp = reader["apellido_emp"].ToString(),
                            rol_area = reader["rol_area"].ToString(),
                            id_usuario = Convert.ToInt32(reader["id_usuario"])
                        });
                    }
                }
            }

            return result;
        }

        public ModelEmpleados Obtener(int id)
        {
            var oEmpleado = new ModelEmpleados();
            var cn = new Connection();

            using (var SQLConnection = new SqlConnection(cn.GetSQLInfo()))
            {
                SQLConnection.Open();

                SqlCommand command = new SqlCommand("ObtenerEmpleado", SQLConnection);
                command.Parameters.AddWithValue("empleadosID", id);
                command.CommandType = CommandType.StoredProcedure;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oEmpleado.empleadosID = Convert.ToInt32(reader["empleadosID"]);
                        oEmpleado.nombre_emp = reader["nombre_emp"].ToString();
                        oEmpleado.apellido_emp = reader["apellido_emp"].ToString();
                        oEmpleado.rol_area = reader["rol_area"].ToString();
                        oEmpleado.id_usuario = Convert.ToInt32(reader["id_usuario"]);
                    }
                }
            }
            return oEmpleado;
        }

        public bool Crear(ModelEmpleados oEmpleado)
        {
            bool result;

            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.GetSQLInfo()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("CrearEmpleado", connection);
                    cmd.Parameters.AddWithValue("nombre_emp", oEmpleado.nombre_emp);
                    cmd.Parameters.AddWithValue("apellido_emp", oEmpleado.apellido_emp);
                    cmd.Parameters.AddWithValue("rol_area", oEmpleado.rol_area);
                    cmd.Parameters.AddWithValue("id_usuario", oEmpleado.id_usuario);
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

        public bool Editar(ModelEmpleados oEmpleado)
        {
            bool result;

            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.GetSQLInfo()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("EditarEmpleado", connection);
                    cmd.Parameters.AddWithValue("empleadosID", oEmpleado.empleadosID);
                    cmd.Parameters.AddWithValue("nombre_emp", oEmpleado.nombre_emp);
                    cmd.Parameters.AddWithValue("apellido_emp", oEmpleado.apellido_emp);
                    cmd.Parameters.AddWithValue("rol_area", oEmpleado.rol_area);
                    cmd.Parameters.AddWithValue("id_usuario", oEmpleado.id_usuario);

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
                    SqlCommand cmd = new SqlCommand("EliminarEmpleado", connection);
                    cmd.Parameters.AddWithValue("empleadosID", id);
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
