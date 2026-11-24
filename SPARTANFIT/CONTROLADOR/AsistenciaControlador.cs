using System;
using System.Data;
using System.Data.SqlClient;
using SPARTANFIT.MODELO;

namespace SPARTANFIT.CONTROLADOR
{
    public static class AsistenciaControlador
    {
        public static DataTable Listar(DateTime? fecha = null, string buscar = "")
        {
            DataTable tabla = new DataTable();
            string sql = "SELECT A.ID_ASISTENCIA, A.ID_INSCRIPCION, A.ID_CREDENCIAL, " +
                         "M.ID_MIEMBRO, M.NOMBRE + ' ' + M.APELLIDO AS MIEMBRO, M.CI, " +
                         "A.FECHA, A.HORA_ENTRADA, I.ESTADO AS ESTADO_INSCRIPCION, C.ESTADO AS ESTADO_CREDENCIAL " +
                         "FROM ASISTENCIAS A INNER JOIN INSCRIPCION I ON I.ID_INSCRIPCION = A.ID_INSCRIPCION " +
                         "INNER JOIN MIEMBRO M ON M.ID_MIEMBRO = I.ID_MIEMBRO " +
                         "INNER JOIN CREDENCIAL C ON C.ID_CREDENCIAL = A.ID_CREDENCIAL " +
                         "WHERE (@FECHA IS NULL OR A.FECHA = @FECHA) AND " +
                         "(@BUSCAR = '' OR M.CI LIKE '%' + @BUSCAR + '%' OR M.NOMBRE LIKE '%' + @BUSCAR + '%' " +
                         "OR M.APELLIDO LIKE '%' + @BUSCAR + '%') ORDER BY A.FECHA DESC, A.HORA_ENTRADA DESC";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = (object)fecha?.Date ?? DBNull.Value;
                cmd.Parameters.Add("@BUSCAR", SqlDbType.NVarChar, 100).Value = buscar ?? "";
                da.Fill(tabla);
            }

            return tabla;
        }

        public static bool Registrar(Asistencia asistencia, out string mensaje)
        {
            string sql = "INSERT INTO ASISTENCIAS (ID_INSCRIPCION, ID_CREDENCIAL, FECHA, HORA_ENTRADA) " +
                         "VALUES (@ID_INSCRIPCION, @ID_CREDENCIAL, ISNULL(@FECHA, CONVERT(DATE, SYSDATETIME())), " +
                         "ISNULL(@HORA_ENTRADA, CONVERT(TIME(0), SYSDATETIME())))";

            return Ejecutar(sql, cmd =>
            {
                cmd.Parameters.Add("@ID_INSCRIPCION", SqlDbType.Int).Value = asistencia.IdInscripcion;
                cmd.Parameters.Add("@ID_CREDENCIAL", SqlDbType.Int).Value = asistencia.IdCredencial;
                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = asistencia.Fecha == DateTime.MinValue ? (object)DBNull.Value : asistencia.Fecha.Date;
                cmd.Parameters.Add("@HORA_ENTRADA", SqlDbType.Time).Value = asistencia.HoraEntrada == TimeSpan.Zero ? (object)DBNull.Value : asistencia.HoraEntrada;
            }, out mensaje);
        }

        public static bool Eliminar(int id, out string mensaje)
        {
            return Ejecutar("DELETE FROM ASISTENCIAS WHERE ID_ASISTENCIA = @ID_ASISTENCIA", cmd =>
            {
                cmd.Parameters.Add("@ID_ASISTENCIA", SqlDbType.Int).Value = id;
            }, out mensaje);
        }

        public static bool Actualizar(Asistencia asistencia, out string mensaje)
        {
            string sql = "UPDATE ASISTENCIAS SET ID_INSCRIPCION = @ID_INSCRIPCION, " +
                         "ID_CREDENCIAL = @ID_CREDENCIAL, FECHA = @FECHA, " +
                         "HORA_ENTRADA = @HORA_ENTRADA WHERE ID_ASISTENCIA = @ID_ASISTENCIA";

            return Ejecutar(sql, cmd =>
            {
                cmd.Parameters.Add("@ID_ASISTENCIA", SqlDbType.Int).Value = asistencia.Id;
                cmd.Parameters.Add("@ID_INSCRIPCION", SqlDbType.Int).Value = asistencia.IdInscripcion;
                cmd.Parameters.Add("@ID_CREDENCIAL", SqlDbType.Int).Value = asistencia.IdCredencial;
                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = asistencia.Fecha.Date;
                cmd.Parameters.Add("@HORA_ENTRADA", SqlDbType.Time).Value = asistencia.HoraEntrada;
            }, out mensaje);
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
