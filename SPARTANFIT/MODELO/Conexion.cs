using System.Data.SqlClient;

namespace SPARTANFIT.MODELO
{
    public static class Conexion
    {
        public const string Servidor = @"FABICITA";
        public const string BaseDatos = "SPARTANFIT";

        public static readonly string CadenaConexion =
            "Data Source=" + Servidor + ";" +
            "Initial Catalog=" + BaseDatos + ";" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;" +
            "Connect Timeout=5;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(CadenaConexion);
        }
    }
}
