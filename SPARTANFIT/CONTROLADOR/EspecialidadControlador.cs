using System;
using System.Data;
using System.Data.SqlClient;
using SPARTANFIT.MODELO;

namespace SPARTANFIT.CONTROLADOR
{
    public static class EspecialidadControlador
    {
        public static DataTable Listar()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ESPECIALIDAD_Listar", cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(tabla);
            }

            return tabla;
        }

        public static bool Registrar(Especialidad especialidad, out string mensaje)
        {
            return Ejecutar("sp_ESPECIALIDAD_Insertar", cmd =>
            {
                cmd.Parameters.Add("@NOMBRE", SqlDbType.NVarChar, 50).Value = especialidad.Nombre;
            }, out mensaje);
        }

        public static bool Actualizar(Especialidad especialidad, out string mensaje)
        {
            return Ejecutar("sp_ESPECIALIDAD_Editar", cmd =>
            {
                cmd.Parameters.Add("@ID_ESPECIALIDAD", SqlDbType.Int).Value = especialidad.Id;
                cmd.Parameters.Add("@NOMBRE", SqlDbType.NVarChar, 50).Value = especialidad.Nombre;
            }, out mensaje);
        }

        public static bool Eliminar(int id, out string mensaje)
        {
            return Ejecutar("sp_ESPECIALIDAD_Eliminar", cmd =>
            {
                cmd.Parameters.Add("@ID_ESPECIALIDAD", SqlDbType.Int).Value = id;
            }, out mensaje);
        }

        private static bool Ejecutar(string procedimiento, Action<SqlCommand> parametros, out string mensaje)
        {
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(procedimiento, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    parametros(cmd);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                mensaje = "";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }
        }
    }
}
