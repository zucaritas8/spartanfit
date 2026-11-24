using System;
using System.Data.SqlClient;
using SPARTANFIT.MODELO;

namespace SPARTANFIT.CONTROLADOR
{
    public static class ConexionControlador
    {
        public static bool ProbarConexion(out string mensaje)
        {
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                {
                    cn.Open();
                    mensaje = "Base de datos conectada: " + Conexion.BaseDatos;
                    return true;
                }
            }
            catch (Exception ex)
            {
                mensaje = "Sin conexión a la base de datos (" + ex.Message + ")";
                return false;
            }
        }
    }
}
