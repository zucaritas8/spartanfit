using System;
using System.Data;
using System.Data.SqlClient;
using SPARTANFIT.MODELO;

namespace SPARTANFIT.CONTROLADOR
{
    public static class EjercicioControlador
    {
        public static DataTable Listar(string buscar = "")
        {
            DataTable tabla = new DataTable();
            string sql = "SELECT ID_EJERCICIO, NOMBRE, DESCRIPCION FROM EJERCICIOS " +
                         "WHERE (@BUSCAR = '' OR NOMBRE LIKE '%' + @BUSCAR + '%' OR DESCRIPCION LIKE '%' + @BUSCAR + '%') " +
                         "ORDER BY NOMBRE";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@BUSCAR", SqlDbType.NVarChar, 100).Value = buscar ?? "";
                da.Fill(tabla);
            }

            return tabla;
        }

        public static bool Registrar(Ejercicio ejercicio, out string mensaje)
        {
            return Ejecutar("sp_EJERCICIOS_Insertar", cmd =>
            {
                cmd.Parameters.Add("@NOMBRE", SqlDbType.NVarChar, 100).Value = ejercicio.Nombre;
                cmd.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar, 255).Value = (object)ejercicio.Descripcion ?? DBNull.Value;
            }, out mensaje);
        }

        public static bool Actualizar(Ejercicio ejercicio, out string mensaje)
        {
            return Ejecutar("sp_EJERCICIOS_Editar", cmd =>
            {
                cmd.Parameters.Add("@ID_EJERCICIO", SqlDbType.Int).Value = ejercicio.Id;
                cmd.Parameters.Add("@NOMBRE", SqlDbType.NVarChar, 100).Value = ejercicio.Nombre;
                cmd.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar, 255).Value = (object)ejercicio.Descripcion ?? DBNull.Value;
            }, out mensaje);
        }

        public static bool Eliminar(int id, out string mensaje)
        {
            return Ejecutar("sp_EJERCICIOS_Eliminar", cmd =>
            {
                cmd.Parameters.Add("@ID_EJERCICIO", SqlDbType.Int).Value = id;
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
