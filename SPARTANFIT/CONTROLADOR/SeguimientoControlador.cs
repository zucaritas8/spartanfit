using System;
using System.Data;
using System.Data.SqlClient;
using SPARTANFIT.MODELO;

namespace SPARTANFIT.CONTROLADOR
{
    public static class SeguimientoControlador
    {
        public static DataTable Listar(int? idObjetivo = null)
        {
            DataTable tabla = new DataTable();
            string sql = "SELECT S.ID_SEGUIMIENTO, S.ID_OBJETIVO, O.TIPO AS OBJETIVO, S.ID_COACH, " +
                         "C.NOMBRE + ' ' + C.APELLIDO AS COACH, S.FECHA, S.VALOR, S.COMENTARIO, " +
                         "M.NOMBRE + ' ' + M.APELLIDO AS MIEMBRO " +
                         "FROM SEGUIMIENTO S INNER JOIN OBJETIVO O ON O.ID_OBJETIVO = S.ID_OBJETIVO " +
                         "INNER JOIN MIEMBRO M ON M.ID_MIEMBRO = O.ID_MIEMBRO " +
                         "LEFT JOIN COACH C ON C.ID_COACH = S.ID_COACH " +
                         "WHERE (@ID_OBJETIVO IS NULL OR S.ID_OBJETIVO = @ID_OBJETIVO) ORDER BY S.FECHA DESC";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@ID_OBJETIVO", SqlDbType.Int).Value = (object)idObjetivo ?? DBNull.Value;
                da.Fill(tabla);
            }

            return tabla;
        }

        public static bool Registrar(Seguimiento seguimiento, out string mensaje)
        {
            string sql = "INSERT INTO SEGUIMIENTO (ID_OBJETIVO, ID_COACH, FECHA, VALOR, COMENTARIO) " +
                         "VALUES (@ID_OBJETIVO, @ID_COACH, ISNULL(@FECHA, SYSDATETIME()), @VALOR, @COMENTARIO)";

            return Ejecutar(sql, cmd => AgregarParametros(cmd, seguimiento), out mensaje);
        }

        public static bool Actualizar(Seguimiento seguimiento, out string mensaje)
        {
            string sql = "UPDATE SEGUIMIENTO SET ID_OBJETIVO = @ID_OBJETIVO, ID_COACH = @ID_COACH, " +
                         "FECHA = @FECHA, VALOR = @VALOR, COMENTARIO = @COMENTARIO " +
                         "WHERE ID_SEGUIMIENTO = @ID_SEGUIMIENTO";

            return Ejecutar(sql, cmd =>
            {
                AgregarParametros(cmd, seguimiento);
                cmd.Parameters.Add("@ID_SEGUIMIENTO", SqlDbType.Int).Value = seguimiento.Id;
            }, out mensaje);
        }

        public static bool Eliminar(int id, out string mensaje)
        {
            return Ejecutar("DELETE FROM SEGUIMIENTO WHERE ID_SEGUIMIENTO = @ID_SEGUIMIENTO", cmd =>
            {
                cmd.Parameters.Add("@ID_SEGUIMIENTO", SqlDbType.Int).Value = id;
            }, out mensaje);
        }

        private static void AgregarParametros(SqlCommand cmd, Seguimiento seguimiento)
        {
            cmd.Parameters.Add("@ID_OBJETIVO", SqlDbType.Int).Value = seguimiento.IdObjetivo;
            cmd.Parameters.Add("@ID_COACH", SqlDbType.Int).Value = (object)seguimiento.IdCoach ?? DBNull.Value;
            cmd.Parameters.Add("@FECHA", SqlDbType.DateTime2).Value = seguimiento.Fecha == DateTime.MinValue ? DateTime.Now : seguimiento.Fecha;
            SqlParameter valor = cmd.Parameters.Add("@VALOR", SqlDbType.Decimal);
            valor.Precision = 6;
            valor.Scale = 2;
            valor.Value = seguimiento.Valor;
            cmd.Parameters.Add("@COMENTARIO", SqlDbType.NVarChar, 255).Value = string.IsNullOrWhiteSpace(seguimiento.Comentario) ? (object)DBNull.Value : seguimiento.Comentario.Trim();
        }

        private static bool Ejecutar(string sql, Action<SqlCommand> parametros, out string mensaje)
        {
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
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
