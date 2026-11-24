using System;

namespace SPARTANFIT.MODELO
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string PasswordHash { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Rol { get; set; }
    }
}
