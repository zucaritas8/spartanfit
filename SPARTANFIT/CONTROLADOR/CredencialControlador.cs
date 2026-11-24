using System;
using System.Data;
using System.Data.SqlClient;
using SPARTANFIT.MODELO;

namespace SPARTANFIT.CONTROLADOR
{
    public static class CredencialControlador
    {
        public static DataTable Listar(string buscar = "")
        {
            DataTable tabla = new DataTable();
            string sql = "SELECT C.ID_CREDENCIAL, C.ID_MIEMBRO, M.CI, M.NOMBRE + ' ' + M.APELLIDO AS MIEMBRO, " +
                         "C.TIPO, C.VALOR, C.ESTADO FROM CREDENCIAL C " +
                         "INNER JOIN MIEMBRO M ON M.ID_MIEMBRO = C.ID_MIEMBRO " +
                         "WHERE (@BUSCAR = '' OR M.CI LIKE '%' + @BUSCAR + '%' OR M.NOMBRE LIKE '%' + @BUSCAR + '%' " +
                         "OR M.APELLIDO LIKE '%' + @BUSCAR + '%' OR C.VALOR LIKE '%' + @BUSCAR + '%') " +
                         "ORDER BY C.ID_CREDENCIAL DESC";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@BUSCAR", SqlDbType.NVarChar, 100).Value = buscar ?? "";
                da.Fill(tabla);
            }

            return tabla;
        }

        public static bool Registrar(Credencial credencial, out string mensaje)
        {
            string sql = "INSERT INTO CREDENCIAL (ID_MIEMBRO, TIPO, VALOR, ESTADO) " +
                         "VALUES (@ID_MIEMBRO, @TIPO, @VALOR, @ESTADO)";

            return Ejecutar(sql, cmd =>
            {
                AgregarParametros(cmd, credencial);
            }, out mensaje);
        }

        public static bool Actualizar(Credencial credencial, out string mensaje)
        {
            string sql = "UPDATE CREDENCIAL SET ID_MIEMBRO = @ID_MIEMBRO, TIPO = @TIPO, " +
                         "VALOR = @VALOR, ESTADO = @ESTADO WHERE ID_CREDENCIAL = @ID_CREDENCIAL";

            return Ejecutar(sql, cmd =>
            {
                AgregarParametros(cmd, credencial);
                cmd.Parameters.Add("@ID_CREDENCIAL", SqlDbType.Int).Value = credencial.Id;
            }, out mensaje);
        }

        public static bool CambiarEstado(int id, string estado, out string mensaje)
        {
            string sql = "UPDATE CREDENCIAL SET ESTADO = @ESTADO WHERE ID_CREDENCIAL = @ID_CREDENCIAL";

            return Ejecutar(sql, cmd =>
            {
                cmd.Parameters.Add("@ESTADO", SqlDbType.NVarChar, 20).Value = estado;
                cmd.Parameters.Add("@ID_CREDENCIAL", SqlDbType.Int).Value = id;
            }, out mensaje);
        }

        private static void AgregarParametros(SqlCommand cmd, Credencial credencial)
        {
            cmd.Parameters.Add("@ID_MIEMBRO", SqlDbType.Int).Value = credencial.IdMiembro;
            cmd.Parameters.Add("@TIPO", SqlDbType.NVarChar, 50).Value = credencial.Tipo;
            cmd.Parameters.Add("@VALOR", SqlDbType.VarChar, 255).Value = credencial.Valor;
            cmd.Parameters.Add("@ESTADO", SqlDbType.NVarChar, 20).Value = string.IsNullOrWhiteSpace(credencial.Estado) ? "ACTIVO" : credencial.Estado;
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
