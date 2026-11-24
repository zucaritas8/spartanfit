using System;
using System.Data;
using System.Data.SqlClient;
using SPARTANFIT.MODELO;

namespace SPARTANFIT.CONTROLADOR
{
    public static class RutinaControlador
    {
        private static object ValorONull(string valor)
        {
            return string.IsNullOrWhiteSpace(valor) ? (object)DBNull.Value : valor.Trim();
        }

        public static DataTable Listar(string buscar = "")
        {
            DataTable tabla = new DataTable();
            string sql = "SELECT R.ID_RUTINA, R.ID_COACH, C.NOMBRE + ' ' + C.APELLIDO AS COACH, " +
                         "R.NOMBRE, R.TIEMPO, R.UNIDAD_TIEMPO, R.DESCRIPCION " +
                         "FROM RUTINAS R INNER JOIN COACH C ON C.ID_COACH = R.ID_COACH " +
                         "WHERE (@BUSCAR = '' OR R.NOMBRE LIKE '%' + @BUSCAR + '%' OR C.NOMBRE LIKE '%' + @BUSCAR + '%' " +
                         "OR C.APELLIDO LIKE '%' + @BUSCAR + '%') ORDER BY R.NOMBRE";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@BUSCAR", SqlDbType.NVarChar, 100).Value = buscar ?? "";
                da.Fill(tabla);
            }

            return tabla;
        }

        public static bool Registrar(Rutina rutina, out string mensaje)
        {
            string sql = "INSERT INTO RUTINAS (ID_COACH, NOMBRE, TIEMPO, UNIDAD_TIEMPO, DESCRIPCION) " +
                         "VALUES (@ID_COACH, @NOMBRE, @TIEMPO, @UNIDAD_TIEMPO, @DESCRIPCION)";

            return Ejecutar(sql, cmd =>
            {
                AgregarParametros(cmd, rutina);
            }, out mensaje);
        }

        public static bool Actualizar(Rutina rutina, out string mensaje)
        {
            string sql = "UPDATE RUTINAS SET ID_COACH = @ID_COACH, NOMBRE = @NOMBRE, TIEMPO = @TIEMPO, " +
                         "UNIDAD_TIEMPO = @UNIDAD_TIEMPO, DESCRIPCION = @DESCRIPCION WHERE ID_RUTINA = @ID_RUTINA";

            return Ejecutar(sql, cmd =>
            {
                AgregarParametros(cmd, rutina);
                cmd.Parameters.Add("@ID_RUTINA", SqlDbType.Int).Value = rutina.Id;
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
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM RUTINA_EJERCICIOS WHERE ID_RUTINA = @ID_RUTINA", cn, transaccion))
                    {
                        cmd.Parameters.Add("@ID_RUTINA", SqlDbType.Int).Value = id;
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand("DELETE FROM RUTINAS WHERE ID_RUTINA = @ID_RUTINA", cn, transaccion))
                    {
                        cmd.Parameters.Add("@ID_RUTINA", SqlDbType.Int).Value = id;
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

        public static DataTable ListarEjercicios(int idRutina)
        {
            DataTable tabla = new DataTable();
            string sql = "SELECT RE.ID_RUTINA, RE.ID_EJERCICIO, E.NOMBRE, RE.NUMERO_SERIES, " +
                         "RE.ORDEN, RE.REPETICIONES FROM RUTINA_EJERCICIOS RE " +
                         "INNER JOIN EJERCICIOS E ON E.ID_EJERCICIO = RE.ID_EJERCICIO " +
                         "WHERE RE.ID_RUTINA = @ID_RUTINA ORDER BY RE.ORDEN";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@ID_RUTINA", SqlDbType.Int).Value = idRutina;
                da.Fill(tabla);
            }

            return tabla;
        }

        public static bool GuardarEjercicio(RutinaEjercicio ejercicio, out string mensaje)
        {
            string sql = "IF EXISTS (SELECT 1 FROM RUTINA_EJERCICIOS WHERE ID_RUTINA = @ID_RUTINA AND ID_EJERCICIO = @ID_EJERCICIO) " +
                         "UPDATE RUTINA_EJERCICIOS SET NUMERO_SERIES = @NUMERO_SERIES, ORDEN = @ORDEN, REPETICIONES = @REPETICIONES " +
                         "WHERE ID_RUTINA = @ID_RUTINA AND ID_EJERCICIO = @ID_EJERCICIO " +
                         "ELSE INSERT INTO RUTINA_EJERCICIOS (ID_RUTINA, ID_EJERCICIO, NUMERO_SERIES, ORDEN, REPETICIONES) " +
                         "VALUES (@ID_RUTINA, @ID_EJERCICIO, @NUMERO_SERIES, @ORDEN, @REPETICIONES)";

            return Ejecutar(sql, cmd =>
            {
                cmd.Parameters.Add("@ID_RUTINA", SqlDbType.Int).Value = ejercicio.IdRutina;
                cmd.Parameters.Add("@ID_EJERCICIO", SqlDbType.Int).Value = ejercicio.IdEjercicio;
                cmd.Parameters.Add("@NUMERO_SERIES", SqlDbType.Int).Value = (object)ejercicio.NumeroSeries ?? DBNull.Value;
                cmd.Parameters.Add("@ORDEN", SqlDbType.Int).Value = ejercicio.Orden;
                cmd.Parameters.Add("@REPETICIONES", SqlDbType.Int).Value = (object)ejercicio.Repeticiones ?? DBNull.Value;
            }, out mensaje);
        }

        public static bool QuitarEjercicio(int idRutina, int idEjercicio, out string mensaje)
        {
            return Ejecutar("DELETE FROM RUTINA_EJERCICIOS WHERE ID_RUTINA = @ID_RUTINA AND ID_EJERCICIO = @ID_EJERCICIO", cmd =>
            {
                cmd.Parameters.Add("@ID_RUTINA", SqlDbType.Int).Value = idRutina;
                cmd.Parameters.Add("@ID_EJERCICIO", SqlDbType.Int).Value = idEjercicio;
            }, out mensaje);
        }

        public static DataTable ListarRegistros()
        {
            DataTable tabla = new DataTable();
            string sql = "SELECT RR.ID_REGISTRO, RR.ID_RUTINA, R.NOMBRE AS RUTINA, RR.ID_MIEMBRO, " +
                         "M.NOMBRE + ' ' + M.APELLIDO AS MIEMBRO, RR.FECHA, RR.RESULTADO " +
                         "FROM REGISTRO_RUTINA RR INNER JOIN RUTINAS R ON R.ID_RUTINA = RR.ID_RUTINA " +
                         "INNER JOIN MIEMBRO M ON M.ID_MIEMBRO = RR.ID_MIEMBRO ORDER BY RR.FECHA DESC";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(tabla);
            }

            return tabla;
        }

        public static bool RegistrarResultado(RegistroRutina registro, out string mensaje)
        {
            string sql = "INSERT INTO REGISTRO_RUTINA (ID_RUTINA, ID_MIEMBRO, FECHA, RESULTADO) " +
                         "VALUES (@ID_RUTINA, @ID_MIEMBRO, ISNULL(@FECHA, SYSDATETIME()), @RESULTADO)";

            return Ejecutar(sql, cmd =>
            {
                cmd.Parameters.Add("@ID_RUTINA", SqlDbType.Int).Value = registro.IdRutina;
                cmd.Parameters.Add("@ID_MIEMBRO", SqlDbType.Int).Value = registro.IdMiembro;
                cmd.Parameters.Add("@FECHA", SqlDbType.DateTime2).Value = registro.Fecha == DateTime.MinValue ? (object)DBNull.Value : registro.Fecha;
                cmd.Parameters.Add("@RESULTADO", SqlDbType.NVarChar, 255).Value = ValorONull(registro.Resultado);
            }, out mensaje);
        }

        private static void AgregarParametros(SqlCommand cmd, Rutina rutina)
        {
            cmd.Parameters.Add("@ID_COACH", SqlDbType.Int).Value = rutina.IdCoach;
            cmd.Parameters.Add("@NOMBRE", SqlDbType.NVarChar, 100).Value = rutina.Nombre;
            cmd.Parameters.Add("@TIEMPO", SqlDbType.Int).Value = (object)rutina.Tiempo ?? DBNull.Value;
            cmd.Parameters.Add("@UNIDAD_TIEMPO", SqlDbType.NVarChar, 20).Value = ValorONull(rutina.UnidadTiempo);
            cmd.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar, 255).Value = ValorONull(rutina.Descripcion);
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
