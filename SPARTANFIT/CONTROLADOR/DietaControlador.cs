using System;
using System.Data;
using System.Data.SqlClient;
using SPARTANFIT.MODELO;

namespace SPARTANFIT.CONTROLADOR
{
    public static class DietaControlador
    {
        private static object ValorONull(string valor)
        {
            return string.IsNullOrWhiteSpace(valor) ? (object)DBNull.Value : valor.Trim();
        }

        public static DataTable Listar(string buscar = "")
        {
            DataTable tabla = new DataTable();
            string sql = "SELECT D.ID_DIETA, D.ID_MIEMBRO, M.NOMBRE + ' ' + M.APELLIDO AS MIEMBRO, " +
                         "D.ID_COACH, C.NOMBRE + ' ' + C.APELLIDO AS COACH, D.FECHA_INICIO, D.FECHA_FIN, " +
                         "D.DESCRIPCION, D.CARBOHIDRATOS_DIARIOS, D.CALORIAS_DIARIAS, D.PROTEINAS_DIARIAS, D.GRASAS_TOTALES " +
                         "FROM DIETA D INNER JOIN MIEMBRO M ON M.ID_MIEMBRO = D.ID_MIEMBRO " +
                         "LEFT JOIN COACH C ON C.ID_COACH = D.ID_COACH " +
                         "WHERE (@BUSCAR = '' OR M.CI LIKE '%' + @BUSCAR + '%' OR M.NOMBRE LIKE '%' + @BUSCAR + '%' " +
                         "OR M.APELLIDO LIKE '%' + @BUSCAR + '%') ORDER BY D.FECHA_INICIO DESC";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@BUSCAR", SqlDbType.NVarChar, 100).Value = buscar ?? "";
                da.Fill(tabla);
            }

            return tabla;
        }

        public static bool Registrar(Dieta dieta, out string mensaje)
        {
            string sql = "INSERT INTO DIETA (ID_MIEMBRO, ID_COACH, FECHA_INICIO, FECHA_FIN, DESCRIPCION, " +
                         "CARBOHIDRATOS_DIARIOS, CALORIAS_DIARIAS, PROTEINAS_DIARIAS, GRASAS_TOTALES) " +
                         "VALUES (@ID_MIEMBRO, @ID_COACH, @FECHA_INICIO, @FECHA_FIN, @DESCRIPCION, " +
                         "@CARBOHIDRATOS_DIARIOS, @CALORIAS_DIARIAS, @PROTEINAS_DIARIAS, @GRASAS_TOTALES)";

            return Ejecutar(sql, cmd => AgregarParametros(cmd, dieta), out mensaje);
        }

        public static bool Actualizar(Dieta dieta, out string mensaje)
        {
            string sql = "UPDATE DIETA SET ID_MIEMBRO = @ID_MIEMBRO, ID_COACH = @ID_COACH, " +
                         "FECHA_INICIO = @FECHA_INICIO, FECHA_FIN = @FECHA_FIN, DESCRIPCION = @DESCRIPCION, " +
                         "CARBOHIDRATOS_DIARIOS = @CARBOHIDRATOS_DIARIOS, CALORIAS_DIARIAS = @CALORIAS_DIARIAS, " +
                         "PROTEINAS_DIARIAS = @PROTEINAS_DIARIAS, GRASAS_TOTALES = @GRASAS_TOTALES WHERE ID_DIETA = @ID_DIETA";

            return Ejecutar(sql, cmd =>
            {
                AgregarParametros(cmd, dieta);
                cmd.Parameters.Add("@ID_DIETA", SqlDbType.Int).Value = dieta.Id;
            }, out mensaje);
        }

        public static bool Eliminar(int id, out string mensaje)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                cn.Open();
                SqlTransaction transaccion = cn.BeginTransaction();

                try
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM DIETA_DETALLE WHERE ID_DIETA = @ID_DIETA", cn, transaccion))
                    {
                        cmd.Parameters.Add("@ID_DIETA", SqlDbType.Int).Value = id;
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand("DELETE FROM DIETA WHERE ID_DIETA = @ID_DIETA", cn, transaccion))
                    {
                        cmd.Parameters.Add("@ID_DIETA", SqlDbType.Int).Value = id;
                        cmd.ExecuteNonQuery();
                    }

                    transaccion.Commit();
                    mensaje = "";
                    return true;
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    mensaje = ex.Message;
                    return false;
                }
            }
        }

        public static DataTable ListarDetalles(int idDieta)
        {
            DataTable tabla = new DataTable();
            string sql = "SELECT ID_DETALLE, ID_DIETA, TIEMPO_COMIDA, DESCRIPCION " +
                         "FROM DIETA_DETALLE WHERE ID_DIETA = @ID_DIETA ORDER BY ID_DETALLE";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@ID_DIETA", SqlDbType.Int).Value = idDieta;
                da.Fill(tabla);
            }

            return tabla;
        }

        public static bool GuardarDetalle(DietaDetalle detalle, out string mensaje)
        {
            string sql = "INSERT INTO DIETA_DETALLE (ID_DIETA, TIEMPO_COMIDA, DESCRIPCION) " +
                         "VALUES (@ID_DIETA, @TIEMPO_COMIDA, @DESCRIPCION)";

            return Ejecutar(sql, cmd =>
            {
                cmd.Parameters.Add("@ID_DIETA", SqlDbType.Int).Value = detalle.IdDieta;
                cmd.Parameters.Add("@TIEMPO_COMIDA", SqlDbType.NVarChar, 50).Value = detalle.TiempoComida;
                cmd.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar, 500).Value = detalle.Descripcion;
            }, out mensaje);
        }

        public static bool ActualizarDetalle(DietaDetalle detalle, out string mensaje)
        {
            string sql = "UPDATE DIETA_DETALLE SET TIEMPO_COMIDA = @TIEMPO_COMIDA, DESCRIPCION = @DESCRIPCION " +
                         "WHERE ID_DETALLE = @ID_DETALLE";

            return Ejecutar(sql, cmd =>
            {
                cmd.Parameters.Add("@TIEMPO_COMIDA", SqlDbType.NVarChar, 50).Value = detalle.TiempoComida;
                cmd.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar, 500).Value = detalle.Descripcion;
                cmd.Parameters.Add("@ID_DETALLE", SqlDbType.Int).Value = detalle.Id;
            }, out mensaje);
        }

        public static bool EliminarDetalle(int id, out string mensaje)
        {
            return Ejecutar("DELETE FROM DIETA_DETALLE WHERE ID_DETALLE = @ID_DETALLE", cmd =>
            {
                cmd.Parameters.Add("@ID_DETALLE", SqlDbType.Int).Value = id;
            }, out mensaje);
        }

        private static void AgregarParametros(SqlCommand cmd, Dieta dieta)
        {
            cmd.Parameters.Add("@ID_MIEMBRO", SqlDbType.Int).Value = dieta.IdMiembro;
            cmd.Parameters.Add("@ID_COACH", SqlDbType.Int).Value = (object)dieta.IdCoach ?? DBNull.Value;
            cmd.Parameters.Add("@FECHA_INICIO", SqlDbType.Date).Value = dieta.FechaInicio.Date;
            cmd.Parameters.Add("@FECHA_FIN", SqlDbType.Date).Value = (object)dieta.FechaFin?.Date ?? DBNull.Value;
            cmd.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar, 255).Value = ValorONull(dieta.Descripcion);
            cmd.Parameters.Add("@CARBOHIDRATOS_DIARIOS", SqlDbType.Int).Value = (object)dieta.CarbohidratosDiarios ?? DBNull.Value;
            cmd.Parameters.Add("@CALORIAS_DIARIAS", SqlDbType.Int).Value = (object)dieta.CaloriasDiarias ?? DBNull.Value;
            cmd.Parameters.Add("@PROTEINAS_DIARIAS", SqlDbType.Int).Value = (object)dieta.ProteinasDiarias ?? DBNull.Value;
            cmd.Parameters.Add("@GRASAS_TOTALES", SqlDbType.Int).Value = (object)dieta.GrasasTotales ?? DBNull.Value;
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
