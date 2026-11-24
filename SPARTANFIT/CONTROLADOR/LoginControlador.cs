using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using SPARTANFIT.MODELO;

namespace SPARTANFIT.CONTROLADOR
{
    public static class LoginControlador
    {
        public static string Hash(string clave)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(clave ?? string.Empty));
                return BitConverter.ToString(bytes).Replace("-", "");
            }
        }

        public static bool Autenticar(string usuario, string clave, out string rol, out string mensaje)
        {
            int idUsuario;
            string nombreCompleto;
            return Autenticar(usuario, clave, out idUsuario, out rol, out nombreCompleto, out mensaje);
        }

        public static bool Autenticar(string usuario, string clave, out int idUsuario, out string rol, out string nombreCompleto, out string mensaje)
        {
            idUsuario = 0;
            rol = string.Empty;
            nombreCompleto = string.Empty;

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_USUARIO_Login", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@USUARIO", SqlDbType.NVarChar, 100).Value = usuario.Trim();
                    cmd.Parameters.Add("@PASSWORD_HASH", SqlDbType.VarChar, 200).Value = Hash(clave);
                    cn.Open();

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (!rd.Read())
                        {
                            mensaje = "Usuario o contraseña incorrectos.";
                            return false;
                        }

                        string estado = Convert.ToString(rd["ESTADO"]);
                        if (!string.Equals(estado, "ACTIVO", StringComparison.OrdinalIgnoreCase))
                        {
                            mensaje = "El usuario está inactivo.";
                            return false;
                        }

                        string rolBase = Convert.ToString(rd["ROL"]);
                        if (string.Equals(rolBase, "ADMIN", StringComparison.OrdinalIgnoreCase))
                            rol = "Administrador";
                        else if (string.Equals(rolBase, "COACH", StringComparison.OrdinalIgnoreCase))
                            rol = "Coach";
                        else if (string.Equals(rolBase, "MIEMBRO", StringComparison.OrdinalIgnoreCase))
                            rol = "Atleta";
                        else
                        {
                            mensaje = "El rol del usuario no es válido.";
                            return false;
                        }

                        idUsuario = Convert.ToInt32(rd["ID_USUARIO"]);
                        nombreCompleto = Convert.ToString(rd["NOMBRE_COMPLETO"]);
                        mensaje = string.Empty;
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                mensaje = "No se pudo conectar a la base de datos.";
                return false;
            }
        }
    }
}
