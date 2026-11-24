using System;
using System.Data;
using System.Data.SqlClient;
using SPARTANFIT.MODELO;

namespace SPARTANFIT.CONTROLADOR
{
    public static class CoachControlador
    {
        private static object ValorONull(string valor)
        {
            return string.IsNullOrWhiteSpace(valor) ? (object)DBNull.Value : valor.Trim();
        }

        public static DataTable Listar(string buscar = "")
        {
            DataTable tabla = new DataTable();
            string sql = "SELECT C.ID_COACH, C.ID_USUARIO, U.USUARIO, C.CI, C.CODIGO, C.NOMBRE, C.APELLIDO, " +
                         "C.DIRECCION, C.TELEFONO, CE.ID_ESPECIALIDAD, E.NOMBRE AS ESPECIALIDAD, " +
                         "CE.FECHA_EMISION, CE.FECHA_EXPIRACION " +
                         "FROM COACH C INNER JOIN USUARIO U ON U.ID_USUARIO = C.ID_USUARIO " +
                         "OUTER APPLY (SELECT TOP 1 ID_ESPECIALIDAD, FECHA_EMISION, FECHA_EXPIRACION " +
                         "FROM COACH_ESPECIALIDAD WHERE ID_COACH = C.ID_COACH ORDER BY ID_ESPECIALIDAD) CE " +
                         "LEFT JOIN ESPECIALIDAD E ON E.ID_ESPECIALIDAD = CE.ID_ESPECIALIDAD " +
                         "WHERE (@BUSCAR = '' OR C.CI LIKE '%' + @BUSCAR + '%' OR C.NOMBRE LIKE '%' + @BUSCAR + '%' " +
                         "OR C.APELLIDO LIKE '%' + @BUSCAR + '%' OR U.USUARIO LIKE '%' + @BUSCAR + '%') " +
                         "ORDER BY C.APELLIDO, C.NOMBRE";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@BUSCAR", SqlDbType.NVarChar, 100).Value = buscar ?? "";
                da.Fill(tabla);
            }

            return tabla;
        }

        public static bool Registrar(Coach coach, out string mensaje)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                cn.Open();
                SqlTransaction transaccion = cn.BeginTransaction();

                try
                {
                    string sqlCoach = "INSERT INTO COACH (ID_USUARIO, CI, CODIGO, NOMBRE, APELLIDO, DIRECCION, TELEFONO) " +
                                      "VALUES (@ID_USUARIO, @CI, @CODIGO, @NOMBRE, @APELLIDO, @DIRECCION, @TELEFONO); " +
                                      "SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    int idCoach;

                    using (SqlCommand cmd = new SqlCommand(sqlCoach, cn, transaccion))
                    {
                        AgregarParametros(cmd, coach);
                        idCoach = (int)cmd.ExecuteScalar();
                    }

                    if (coach.IdEspecialidad.HasValue && coach.IdEspecialidad.Value > 0)
                    {
                        InsertarEspecialidad(cn, transaccion, idCoach, coach);
                    }

                    using (SqlCommand cmd = new SqlCommand("UPDATE USUARIO SET ROL = 'COACH' WHERE ID_USUARIO = @ID_USUARIO", cn, transaccion))
                    {
                        cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int).Value = coach.IdUsuario;
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

        public static bool Actualizar(Coach coach, out string mensaje)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                cn.Open();
                SqlTransaction transaccion = cn.BeginTransaction();

                try
                {
                    string sql = "UPDATE COACH SET ID_USUARIO = @ID_USUARIO, CI = @CI, CODIGO = @CODIGO, " +
                                 "NOMBRE = @NOMBRE, APELLIDO = @APELLIDO, DIRECCION = @DIRECCION, TELEFONO = @TELEFONO " +
                                 "WHERE ID_COACH = @ID_COACH";

                    using (SqlCommand cmd = new SqlCommand(sql, cn, transaccion))
                    {
                        AgregarParametros(cmd, coach);
                        cmd.Parameters.Add("@ID_COACH", SqlDbType.Int).Value = coach.Id;
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand("DELETE FROM COACH_ESPECIALIDAD WHERE ID_COACH = @ID_COACH", cn, transaccion))
                    {
                        cmd.Parameters.Add("@ID_COACH", SqlDbType.Int).Value = coach.Id;
                        cmd.ExecuteNonQuery();
                    }

                    if (coach.IdEspecialidad.HasValue && coach.IdEspecialidad.Value > 0)
                    {
                        InsertarEspecialidad(cn, transaccion, coach.Id, coach);
                    }

                    using (SqlCommand cmd = new SqlCommand("UPDATE USUARIO SET ROL = 'COACH' WHERE ID_USUARIO = @ID_USUARIO", cn, transaccion))
                    {
                        cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int).Value = coach.IdUsuario;
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

        public static bool Desactivar(int idUsuario, out string mensaje)
        {
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("UPDATE USUARIO SET ESTADO = 'INACTIVO' WHERE ID_USUARIO = @ID_USUARIO", cn))
                {
                    cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int).Value = idUsuario;
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

        private static void AgregarParametros(SqlCommand cmd, Coach coach)
        {
            cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int).Value = coach.IdUsuario;
            cmd.Parameters.Add("@CI", SqlDbType.VarChar, 20).Value = coach.CI;
            cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 20).Value = coach.Codigo;
            cmd.Parameters.Add("@NOMBRE", SqlDbType.NVarChar, 50).Value = coach.Nombre;
            cmd.Parameters.Add("@APELLIDO", SqlDbType.NVarChar, 50).Value = coach.Apellido;
            cmd.Parameters.Add("@DIRECCION", SqlDbType.NVarChar, 200).Value = ValorONull(coach.Direccion);
            cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar, 20).Value = ValorONull(coach.Telefono);
        }

        private static void InsertarEspecialidad(SqlConnection cn, SqlTransaction transaccion, int idCoach, Coach coach)
        {
            string sql = "INSERT INTO COACH_ESPECIALIDAD (ID_COACH, ID_ESPECIALIDAD, FECHA_EMISION, FECHA_EXPIRACION) " +
                         "VALUES (@ID_COACH, @ID_ESPECIALIDAD, @FECHA_EMISION, @FECHA_EXPIRACION)";

            using (SqlCommand cmd = new SqlCommand(sql, cn, transaccion))
            {
                cmd.Parameters.Add("@ID_COACH", SqlDbType.Int).Value = idCoach;
                cmd.Parameters.Add("@ID_ESPECIALIDAD", SqlDbType.Int).Value = coach.IdEspecialidad.Value;
                cmd.Parameters.Add("@FECHA_EMISION", SqlDbType.Date).Value = (object)coach.FechaEmision ?? DBNull.Value;
                cmd.Parameters.Add("@FECHA_EXPIRACION", SqlDbType.Date).Value = (object)coach.FechaExpiracion ?? DBNull.Value;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
