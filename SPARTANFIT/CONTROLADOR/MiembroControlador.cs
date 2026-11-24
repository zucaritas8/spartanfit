using System;
using System.Data;
using System.Data.SqlClient;
using SPARTANFIT.MODELO;

namespace SPARTANFIT.CONTROLADOR
{
    public static class MiembroControlador
    {
        private static object ValorONull(string texto)
        {
            return string.IsNullOrWhiteSpace(texto) ? (object)DBNull.Value : texto.Trim();
        }

        private static void AgregarParametros(SqlCommand cmd, Miembro miembro)
        {
            cmd.Parameters.Add("@CI", SqlDbType.VarChar, 20).Value = miembro.CI;
            cmd.Parameters.Add("@NOMBRE", SqlDbType.NVarChar, 50).Value = miembro.Nombre;
            cmd.Parameters.Add("@APELLIDO", SqlDbType.NVarChar, 50).Value = miembro.Apellidos;
            cmd.Parameters.Add("@DIRECCION", SqlDbType.NVarChar, 150).Value = ValorONull(miembro.Direccion);
            cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar, 20).Value = ValorONull(miembro.Telefono);
            cmd.Parameters.Add("@CORREO_ELECTRONICO", SqlDbType.NVarChar, 100).Value = ValorONull(miembro.Correo);
            cmd.Parameters.Add("@FECHA_NACIMIENTO", SqlDbType.Date).Value = miembro.FechaNacimiento.Date;
        }

        public static DataTable Listar(string buscar = "")
        {
            DataTable tabla = new DataTable();
            string sql = "SELECT M.ID_MIEMBRO, M.ID_USUARIO, U.USUARIO, M.CI, M.NOMBRE, M.APELLIDO, " +
                         "M.DIRECCION, M.TELEFONO, M.CORREO_ELECTRONICO, M.FECHA_NACIMIENTO " +
                         "FROM MIEMBRO M INNER JOIN USUARIO U ON U.ID_USUARIO = M.ID_USUARIO " +
                         "WHERE (@BUSCAR = '' OR M.CI LIKE '%' + @BUSCAR + '%' OR M.NOMBRE LIKE '%' + @BUSCAR + '%' " +
                         "OR M.APELLIDO LIKE '%' + @BUSCAR + '%') ORDER BY M.APELLIDO, M.NOMBRE";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@BUSCAR", SqlDbType.NVarChar, 100).Value = buscar ?? "";
                da.Fill(tabla);
            }

            return tabla;
        }

        public static bool Registrar(Miembro miembro, string modalidad, out string usuario, out string mensaje)
        {
            usuario = "miembro_" + miembro.CI;

            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                cn.Open();
                SqlTransaction transaccion = cn.BeginTransaction();

                try
                {
                    string sqlUsuario = "INSERT INTO USUARIO (USUARIO, PASSWORD_HASH, ESTADO, ROL) " +
                                        "VALUES (@USUARIO, @PASSWORD_HASH, 'ACTIVO', 'MIEMBRO'); " +
                                        "SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    int idUsuario;

                    using (SqlCommand cmd = new SqlCommand(sqlUsuario, cn, transaccion))
                    {
                        cmd.Parameters.Add("@USUARIO", SqlDbType.NVarChar, 100).Value = usuario;
                        cmd.Parameters.Add("@PASSWORD_HASH", SqlDbType.VarChar, 200).Value = LoginControlador.Hash(miembro.CI);
                        idUsuario = (int)cmd.ExecuteScalar();
                    }

                    string sqlMiembro = "INSERT INTO MIEMBRO (ID_USUARIO, CI, NOMBRE, APELLIDO, DIRECCION, TELEFONO, CORREO_ELECTRONICO, FECHA_NACIMIENTO) " +
                                        "VALUES (@ID_USUARIO, @CI, @NOMBRE, @APELLIDO, @DIRECCION, @TELEFONO, @CORREO_ELECTRONICO, @FECHA_NACIMIENTO)";

                    using (SqlCommand cmd = new SqlCommand(sqlMiembro, cn, transaccion))
                    {
                        cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int).Value = idUsuario;
                        AgregarParametros(cmd, miembro);
                        cmd.ExecuteNonQuery();
                    }

                    if (!string.IsNullOrWhiteSpace(modalidad))
                    {
                        DateTime inicio = DateTime.Today;
                        DateTime fin = string.Equals(modalidad, "MENSUAL", StringComparison.OrdinalIgnoreCase)
                            ? inicio.AddMonths(1)
                            : inicio;

                        string sqlInscripcion = "INSERT INTO INSCRIPCION (ID_MIEMBRO, FECHA_INICIO, FECHA_FIN, MODALIDAD, ESTADO) " +
                                                 "SELECT ID_MIEMBRO, @FECHA_INICIO, @FECHA_FIN, @MODALIDAD, 'ACTIVO' " +
                                                 "FROM MIEMBRO WHERE ID_USUARIO = @ID_USUARIO";

                        using (SqlCommand cmd = new SqlCommand(sqlInscripcion, cn, transaccion))
                        {
                            cmd.Parameters.Add("@FECHA_INICIO", SqlDbType.Date).Value = inicio;
                            cmd.Parameters.Add("@FECHA_FIN", SqlDbType.Date).Value = fin;
                            cmd.Parameters.Add("@MODALIDAD", SqlDbType.NVarChar, 50).Value = modalidad;
                            cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int).Value = idUsuario;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaccion.Commit();
                    mensaje = "";
                    return true;
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    usuario = "";
                    mensaje = MensajeError(ex);
                    return false;
                }
            }
        }

        public static bool Actualizar(Miembro miembro, out string mensaje)
        {
            string sql = "UPDATE MIEMBRO SET CI = @CI, NOMBRE = @NOMBRE, APELLIDO = @APELLIDO, " +
                         "DIRECCION = @DIRECCION, TELEFONO = @TELEFONO, CORREO_ELECTRONICO = @CORREO_ELECTRONICO, " +
                         "FECHA_NACIMIENTO = @FECHA_NACIMIENTO WHERE ID_MIEMBRO = @ID_MIEMBRO";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    AgregarParametros(cmd, miembro);
                    cmd.Parameters.Add("@ID_MIEMBRO", SqlDbType.Int).Value = miembro.Id;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                mensaje = "";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = MensajeError(ex);
                return false;
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
                mensaje = MensajeError(ex);
                return false;
            }
        }

        private static string MensajeError(Exception ex)
        {
            SqlException sql = ex as SqlException;

            if (sql != null && (sql.Number == 2627 || sql.Number == 2601))
                return "Ya existe un registro con esos datos.";

            return "No se pudo completar la operación. Revisa la conexión y los datos ingresados.";
        }
    }
}
