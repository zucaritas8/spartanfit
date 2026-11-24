using System;
using System.Data;
using System.Data.SqlClient;
using SPARTANFIT.MODELO;

namespace SPARTANFIT.CONTROLADOR
{
    public static class InscripcionControlador
    {
        public static DataTable Listar(string buscar = "")
        {
            DataTable tabla = new DataTable();
            string sql = "SELECT I.ID_INSCRIPCION, I.ID_MIEMBRO, M.CI, M.NOMBRE + ' ' + M.APELLIDO AS MIEMBRO, " +
                         "I.FECHA_INICIO, I.FECHA_FIN, I.MODALIDAD, I.ESTADO " +
                         "FROM INSCRIPCION I INNER JOIN MIEMBRO M ON M.ID_MIEMBRO = I.ID_MIEMBRO " +
                         "WHERE (@BUSCAR = '' OR M.CI LIKE '%' + @BUSCAR + '%' OR M.NOMBRE LIKE '%' + @BUSCAR + '%' " +
                         "OR M.APELLIDO LIKE '%' + @BUSCAR + '%') ORDER BY I.FECHA_INICIO DESC";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@BUSCAR", SqlDbType.NVarChar, 100).Value = buscar ?? "";
                da.Fill(tabla);
            }

            return tabla;
        }

        public static bool Registrar(Inscripcion inscripcion, out string mensaje)
        {
            string sql = "INSERT INTO INSCRIPCION (ID_MIEMBRO, FECHA_INICIO, FECHA_FIN, MODALIDAD, ESTADO) " +
                         "VALUES (@ID_MIEMBRO, @FECHA_INICIO, @FECHA_FIN, @MODALIDAD, @ESTADO)";

            return Ejecutar(sql, cmd =>
            {
                AgregarParametros(cmd, inscripcion);
            }, out mensaje);
        }

        public static bool Actualizar(Inscripcion inscripcion, out string mensaje)
        {
            string sql = "UPDATE INSCRIPCION SET ID_MIEMBRO = @ID_MIEMBRO, FECHA_INICIO = @FECHA_INICIO, " +
                         "FECHA_FIN = @FECHA_FIN, MODALIDAD = @MODALIDAD, ESTADO = @ESTADO " +
                         "WHERE ID_INSCRIPCION = @ID_INSCRIPCION";

            return Ejecutar(sql, cmd =>
            {
                AgregarParametros(cmd, inscripcion);
                cmd.Parameters.Add("@ID_INSCRIPCION", SqlDbType.Int).Value = inscripcion.Id;
            }, out mensaje);
        }

        public static bool Cancelar(int id, out string mensaje)
        {
            string sql = "UPDATE INSCRIPCION SET ESTADO = N'CANCELADO' WHERE ID_INSCRIPCION = @ID_INSCRIPCION";

            return Ejecutar(sql, cmd =>
            {
                cmd.Parameters.Add("@ID_INSCRIPCION", SqlDbType.Int).Value = id;
            }, out mensaje);
        }

        private static void AgregarParametros(SqlCommand cmd, Inscripcion inscripcion)
        {
            cmd.Parameters.Add("@ID_MIEMBRO", SqlDbType.Int).Value = inscripcion.IdMiembro;
            cmd.Parameters.Add("@FECHA_INICIO", SqlDbType.Date).Value = inscripcion.FechaInicio.Date;
            cmd.Parameters.Add("@FECHA_FIN", SqlDbType.Date).Value = inscripcion.FechaFin.Date;
            cmd.Parameters.Add("@MODALIDAD", SqlDbType.NVarChar, 50).Value = inscripcion.Modalidad;
            cmd.Parameters.Add("@ESTADO", SqlDbType.NVarChar, 20).Value = string.IsNullOrWhiteSpace(inscripcion.Estado) ? "ACTIVO" : inscripcion.Estado;
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
