using CRUD1.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUD1.Data
{
    public class PromocionData
    {

        public List<ModelPromocion> Listar()
        {
            var result = new List<ModelPromocion>();
            var connection = new Connection();

            using (var SQLConnection = new SqlConnection(connection.GetSQLInfo()))
            {
                SQLConnection.Open();

                SqlCommand command = new SqlCommand("ListarPromocion", SQLConnection);
                command.CommandType = CommandType.StoredProcedure;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new ModelPromocion()
                        {
                            promocionID = Convert.ToInt32(reader["promocionID"]),
                            descuento = Convert.ToDecimal(reader["descuento"]),
                            nom_promo = reader["nom_promo"].ToString()
                        });
                    }
                }
            }

            return result;
        }

        public ModelPromocion Obtener(int id)
        {
            var oPromocion = new ModelPromocion();
            var cn = new Connection();

            using (var SQLConnection = new SqlConnection(cn.GetSQLInfo()))
            {
                SQLConnection.Open();

                SqlCommand command = new SqlCommand("ObtenerPromocion", SQLConnection);
                command.Parameters.AddWithValue("promocionID", id);
                command.CommandType = CommandType.StoredProcedure;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oPromocion.promocionID = Convert.ToInt32(reader["promocionID"]);
                        oPromocion.descuento = Convert.ToDecimal(reader["descuento"]);
                        oPromocion.nom_promo = reader["nom_promo"].ToString();
                    }
                }
            }
            return oPromocion;
        }

        public bool Crear(ModelPromocion oPromocion)
        {
            bool result;

            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.GetSQLInfo()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("CrearPromocion", connection);
                    cmd.Parameters.AddWithValue("descuento", oPromocion.descuento);
                    cmd.Parameters.AddWithValue("nom_promo", oPromocion.nom_promo);
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

        public bool Editar(ModelPromocion oPromocion)
        {
            bool result;

            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.GetSQLInfo()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("EditarPromocion", connection);
                    cmd.Parameters.AddWithValue("promocionID", oPromocion.promocionID);
                    cmd.Parameters.AddWithValue("descuento", oPromocion.descuento);
                    cmd.Parameters.AddWithValue("nom_promo", oPromocion.nom_promo);

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
                    SqlCommand cmd = new SqlCommand("EliminarPromocion", connection);
                    cmd.Parameters.AddWithValue("promocionID", id);
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
