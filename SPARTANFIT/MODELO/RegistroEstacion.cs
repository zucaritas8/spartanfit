using System;

namespace SPARTANFIT.MODELO
{
    public class RegistroEstacion
    {
        public int Id { get; set; }
        public int IdEstacion { get; set; }
        public int IdMiembro { get; set; }
        public string NombreEstacion { get; set; }
        public string NombreMiembro { get; set; }
        public DateTime Fecha { get; set; }
        public string Resultado { get; set; }
    }
}
