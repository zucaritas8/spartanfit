using System;
using System.Data;
using System.Data.SqlClient;
using SPARTANFIT.MODELO;

namespace SPARTANFIT.CONTROLADOR
{
    public static class ObjetivoControlador
    {
        private static object ValorONull(string valor)
        {
            return string.IsNullOrWhiteSpace(valor) ? (object)DBNull.Value : valor.Trim();
        }

        public static DataTable Listar(string buscar = "")
        {
            DataTable tabla = new DataTable();
            string sql = "SELECT O.ID_OBJETIVO, O.ID_MIEMBRO, M.NOMBRE + ' ' + M.APELLIDO AS MIEMBRO, " +
                         "O.TIPO, O.DESCRIPCION, O.VALOR_INICIAL, O.VALOR_META, O.UNIDAD, O.FECHA_INICIO, O.FECHA_FIN " +
                         "FROM OBJETIVO O INNER JOIN MIEMBRO M ON M.ID_MIEMBRO = O.ID_MIEMBRO " +
                         "WHERE (@BUSCAR = '' OR M.CI LIKE '%' + @BUSCAR + '%' OR M.NOMBRE LIKE '%' + @BUSCAR + '%' " +
                         "OR M.APELLIDO LIKE '%' + @BUSCAR + '%' OR O.TIPO LIKE '%' + @BUSCAR + '%') " +
                         "ORDER BY O.FECHA_INICIO DESC";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@BUSCAR", SqlDbType.NVarChar, 100).Value = buscar ?? "";
                da.Fill(tabla);
            }

            return tabla;
        }

        public static bool Registrar(Objetivo objetivo, out string mensaje)
        {
            string sql = "INSERT INTO OBJETIVO (ID_MIEMBRO, TIPO, DESCRIPCION, VALOR_INICIAL, VALOR_META, UNIDAD, FECHA_INICIO, FECHA_FIN) " +
                         "VALUES (@ID_MIEMBRO, @TIPO, @DESCRIPCION, @VALOR_INICIAL, @VALOR_META, @UNIDAD, @FECHA_INICIO, @FECHA_FIN)";

            return Ejecutar(sql, cmd => AgregarParametros(cmd, objetivo), out mensaje);
        }

        public static bool Actualizar(Objetivo objetivo, out string mensaje)
        {
            string sql = "UPDATE OBJETIVO SET ID_MIEMBRO = @ID_MIEMBRO, TIPO = @TIPO, DESCRIPCION = @DESCRIPCION, " +
                         "VALOR_INICIAL = @VALOR_INICIAL, VALOR_META = @VALOR_META, UNIDAD = @UNIDAD, " +
                         "FECHA_INICIO = @FECHA_INICIO, FECHA_FIN = @FECHA_FIN WHERE ID_OBJETIVO = @ID_OBJETIVO";

            return Ejecutar(sql, cmd =>
            {
                AgregarParametros(cmd, objetivo);
                cmd.Parameters.Add("@ID_OBJETIVO", SqlDbType.Int).Value = objetivo.Id;
            }, out mensaje);
        }

        public static bool Eliminar(int id, out string mensaje)
        {
            return Ejecutar("DELETE FROM OBJETIVO WHERE ID_OBJETIVO = @ID_OBJETIVO", cmd =>
            {
                cmd.Parameters.Add("@ID_OBJETIVO", SqlDbType.Int).Value = id;
            }, out mensaje);
        }

        private static void AgregarParametros(SqlCommand cmd, Objetivo objetivo)
        {
            cmd.Parameters.Add("@ID_MIEMBRO", SqlDbType.Int).Value = objetivo.IdMiembro;
            cmd.Parameters.Add("@TIPO", SqlDbType.NVarChar, 50).Value = objetivo.Tipo;
            cmd.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar, 255).Value = ValorONull(objetivo.Descripcion);
            SqlParameter valorInicial = cmd.Parameters.Add("@VALOR_INICIAL", SqlDbType.Decimal);
            valorInicial.Precision = 6;
            valorInicial.Scale = 2;
            valorInicial.Value = (object)objetivo.ValorInicial ?? DBNull.Value;

            SqlParameter valorMeta = cmd.Parameters.Add("@VALOR_META", SqlDbType.Decimal);
            valorMeta.Precision = 6;
            valorMeta.Scale = 2;
            valorMeta.Value = (object)objetivo.ValorMeta ?? DBNull.Value;
            cmd.Parameters.Add("@UNIDAD", SqlDbType.NVarChar, 20).Value = string.IsNullOrWhiteSpace(objetivo.Unidad) ? "KG" : objetivo.Unidad;
            cmd.Parameters.Add("@FECHA_INICIO", SqlDbType.Date).Value = objetivo.FechaInicio.Date;
            cmd.Parameters.Add("@FECHA_FIN", SqlDbType.Date).Value = (object)objetivo.FechaFin?.Date ?? DBNull.Value;
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
