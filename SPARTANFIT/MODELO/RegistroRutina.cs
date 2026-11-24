using System;

namespace SPARTANFIT.MODELO
{
    public class RegistroRutina
    {
        public int Id { get; set; }
        public int IdRutina { get; set; }
        public int IdMiembro { get; set; }
        public string NombreRutina { get; set; }
        public string NombreMiembro { get; set; }
        public DateTime Fecha { get; set; }
        public string Resultado { get; set; }
    }
}
