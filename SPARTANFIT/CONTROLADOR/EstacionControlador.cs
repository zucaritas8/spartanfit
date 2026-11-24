using System;
using System.Data;
using System.Data.SqlClient;
using SPARTANFIT.MODELO;

namespace SPARTANFIT.CONTROLADOR
{
    public static class EstacionControlador
    {
        private static object ValorONull(string valor)
        {
            return string.IsNullOrWhiteSpace(valor)
                ? (object)DBNull.Value
                : valor.Trim();
        }

        public static DataTable Listar(string buscar = "")
        {
            DataTable tabla = new DataTable();

            string sql = @"SELECT ID_ESTACION, NOMBRE, DESCRIPCION, EQUIPAMIENTO
                           FROM ESTACION
                           WHERE (@BUSCAR = ''
                           OR NOMBRE LIKE '%' + @BUSCAR + '%'
                           OR DESCRIPCION LIKE '%' + @BUSCAR + '%')
                           ORDER BY NOMBRE";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@BUSCAR", SqlDbType.NVarChar, 100)
                    .Value = buscar ?? "";

                da.Fill(tabla);
            }

            return tabla;
        }

        public static bool Registrar(Estacion estacion, out string mensaje)
        {
            return Ejecutar("sp_ESTACION_Insertar", cmd =>
            {
                cmd.Parameters.Add("@NOMBRE", SqlDbType.NVarChar, 100)
                    .Value = estacion.Nombre;

                cmd.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar, 255)
                    .Value = ValorONull(estacion.Descripcion);

                cmd.Parameters.Add("@EQUIPAMIENTO", SqlDbType.NVarChar, 255)
                    .Value = ValorONull(estacion.Equipamiento);

            }, out mensaje);
        }

        public static bool Actualizar(Estacion estacion, out string mensaje)
        {
            return Ejecutar("sp_ESTACION_Editar", cmd =>
            {
                cmd.Parameters.Add("@ID_ESTACION", SqlDbType.Int)
                    .Value = estacion.Id;

                cmd.Parameters.Add("@NOMBRE", SqlDbType.NVarChar, 100)
                    .Value = estacion.Nombre;

                cmd.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar, 255)
                    .Value = ValorONull(estacion.Descripcion);

                cmd.Parameters.Add("@EQUIPAMIENTO", SqlDbType.NVarChar, 255)
                    .Value = ValorONull(estacion.Equipamiento);

            }, out mensaje);
        }

        public static bool Eliminar(int id, out string mensaje)
        {
            return Ejecutar("sp_ESTACION_Eliminar", cmd =>
            {
                cmd.Parameters.Add("@ID_ESTACION", SqlDbType.Int)
                    .Value = id;

            }, out mensaje);
        }

        public static DataTable ListarEjercicios(int idEstacion)
        {
            DataTable tabla = new DataTable();

            string sql = @"SELECT EE.ID_ESTACION, EE.ID_EJERCICIO,
                                  E.NOMBRE, EE.ORDEN, EE.NUMERO_SERIES,
                                  EE.REPETICIONES, EE.TIEMPO
                           FROM ESTACION_EJERCICIO EE
                           INNER JOIN EJERCICIOS E
                           ON E.ID_EJERCICIO = EE.ID_EJERCICIO
                           WHERE EE.ID_ESTACION = @ID_ESTACION
                           ORDER BY EE.ORDEN";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@ID_ESTACION", SqlDbType.Int)
                    .Value = idEstacion;

                da.Fill(tabla);
            }

            return tabla;
        }

        public static bool GuardarEjercicio(EstacionEjercicio ejercicio, out string mensaje)
        {
            string sql = @"IF EXISTS (
                               SELECT 1 FROM ESTACION_EJERCICIO
                               WHERE ID_ESTACION = @ID_ESTACION
                               AND ID_EJERCICIO = @ID_EJERCICIO
                           )
                           UPDATE ESTACION_EJERCICIO
                           SET ORDEN = @ORDEN,
                               NUMERO_SERIES = @NUMERO_SERIES,
                               REPETICIONES = @REPETICIONES,
                               TIEMPO = @TIEMPO
                           WHERE ID_ESTACION = @ID_ESTACION
                           AND ID_EJERCICIO = @ID_EJERCICIO
                           ELSE
                           INSERT INTO ESTACION_EJERCICIO
                           (ID_ESTACION, ID_EJERCICIO, ORDEN,
                            NUMERO_SERIES, REPETICIONES, TIEMPO)
                           VALUES
                           (@ID_ESTACION, @ID_EJERCICIO, @ORDEN,
                            @NUMERO_SERIES, @REPETICIONES, @TIEMPO)";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add("@ID_ESTACION", SqlDbType.Int)
                        .Value = ejercicio.IdEstacion;

                    cmd.Parameters.Add("@ID_EJERCICIO", SqlDbType.Int)
                        .Value = ejercicio.IdEjercicio;

                    cmd.Parameters.Add("@ORDEN", SqlDbType.Int)
                        .Value = ejercicio.Orden;

                    cmd.Parameters.Add("@NUMERO_SERIES", SqlDbType.Int)
                        .Value = (object)ejercicio.NumeroSeries ?? DBNull.Value;

                    cmd.Parameters.Add("@REPETICIONES", SqlDbType.Int)
                        .Value = (object)ejercicio.Repeticiones ?? DBNull.Value;

                    cmd.Parameters.Add("@TIEMPO", SqlDbType.VarChar, 20)
                        .Value = ValorONull(ejercicio.Tiempo);

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

        public static bool QuitarEjercicio(int idEstacion, int idEjercicio, out string mensaje)
        {
            return EjecutarSql(
                @"DELETE FROM ESTACION_EJERCICIO
                  WHERE ID_ESTACION = @ID_ESTACION
                  AND ID_EJERCICIO = @ID_EJERCICIO",
                cmd =>
                {
                    cmd.Parameters.Add("@ID_ESTACION", SqlDbType.Int)
                        .Value = idEstacion;

                    cmd.Parameters.Add("@ID_EJERCICIO", SqlDbType.Int)
                        .Value = idEjercicio;
                },
                out mensaje
            );
        }

        public static DataTable ListarRegistros()
        {
            DataTable tabla = new DataTable();

            string sql = @"SELECT R.ID_REGISTRO, R.ID_ESTACION,
                                  E.NOMBRE AS ESTACION,
                                  R.ID_MIEMBRO,
                                  M.NOMBRE + ' ' + M.APELLIDOS AS MIEMBRO,
                                  R.FECHA, R.RESULTADO
                           FROM REGISTRO_ESTACION R
                           INNER JOIN ESTACION E
                           ON E.ID_ESTACION = R.ID_ESTACION
                           INNER JOIN MIEMBRO M
                           ON M.ID_MIEMBRO = R.ID_MIEMBRO
                           ORDER BY R.FECHA DESC";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(tabla);
            }

            return tabla;
        }

        public static bool RegistrarResultado(RegistroEstacion registro, out string mensaje)
        {
            string sql = @"INSERT INTO REGISTRO_ESTACION
                           (ID_ESTACION, ID_MIEMBRO, FECHA, RESULTADO)
                           VALUES
                           (@ID_ESTACION, @ID_MIEMBRO,
                            ISNULL(@FECHA, SYSDATETIME()), @RESULTADO)";

            return EjecutarSql(sql, cmd =>
            {
                cmd.Parameters.Add("@ID_ESTACION", SqlDbType.Int)
                    .Value = registro.IdEstacion;

                cmd.Parameters.Add("@ID_MIEMBRO", SqlDbType.Int)
                    .Value = registro.IdMiembro;

                cmd.Parameters.Add("@FECHA", SqlDbType.DateTime2)
                    .Value = registro.Fecha == DateTime.MinValue
                    ? (object)DBNull.Value
                    : registro.Fecha;

                cmd.Parameters.Add("@RESULTADO", SqlDbType.NVarChar, 255)
                    .Value = ValorONull(registro.Resultado);

            }, out mensaje);
        }

        private static bool Ejecutar(
            string procedimiento,
            Action<SqlCommand> parametros,
            out string mensaje)
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

        private static bool EjecutarSql(
            string sql,
            Action<SqlCommand> parametros,
            out string mensaje)
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