using System;

namespace SPARTANFIT.MODELO
{
    public class Inscripcion
    {
        public int Id { get; set; }
        public int IdMiembro { get; set; }
        public string NombreMiembro { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Modalidad { get; set; }
        public string Estado { get; set; }
    }
}
