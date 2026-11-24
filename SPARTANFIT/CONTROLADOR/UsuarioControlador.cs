using System.Data;
using System.Data.SqlClient;
using SPARTANFIT.MODELO;

namespace SPARTANFIT.CONTROLADOR
{
    public static class UsuarioControlador
    {
        public static DataTable Listar()
        {
            DataTable tabla = new DataTable();

            string sql = "SELECT ID_USUARIO, USUARIO, ESTADO, FECHA_CREACION, ROL FROM USUARIO ORDER BY ID_USUARIO";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(tabla);
            }

            return tabla;
        }

        public static bool Registrar(Usuario usuario, out string mensaje)
        {
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_USUARIO_Insertar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@USUARIO", SqlDbType.NVarChar, 100).Value = usuario.NombreUsuario;
                    cmd.Parameters.Add("@PASSWORD_HASH", SqlDbType.VarChar, 200).Value = usuario.PasswordHash;
                    cmd.Parameters.Add("@ESTADO", SqlDbType.VarChar, 50).Value = string.IsNullOrWhiteSpace(usuario.Estado) ? "ACTIVO" : usuario.Estado;
                    cmd.Parameters.Add("@ROL", SqlDbType.VarChar, 20).Value = string.IsNullOrWhiteSpace(usuario.Rol) ? "MIEMBRO" : usuario.Rol;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                mensaje = "";
                return true;
            }
            catch (System.Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }
        }

        public static bool Actualizar(Usuario usuario, out string mensaje)
        {
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_USUARIO_Editar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int).Value = usuario.Id;
                    cmd.Parameters.Add("@USUARIO", SqlDbType.NVarChar, 100).Value = usuario.NombreUsuario;
                    cmd.Parameters.Add("@PASSWORD_HASH", SqlDbType.VarChar, 200).Value = usuario.PasswordHash;
                    cmd.Parameters.Add("@ESTADO", SqlDbType.VarChar, 50).Value = usuario.Estado;
                    cmd.Parameters.Add("@ROL", SqlDbType.VarChar, 20).Value = usuario.Rol;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                mensaje = "";
                return true;
            }
            catch (System.Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }
        }

        public static bool Desactivar(int idUsuario, out string mensaje)
        {
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_USUARIO_Eliminar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int).Value = idUsuario;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                mensaje = "";
                return true;
            }
            catch (System.Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }
        }
    }
}
