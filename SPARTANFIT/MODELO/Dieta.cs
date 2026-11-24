using System;

namespace SPARTANFIT.MODELO
{
    public class Dieta
    {
        public int Id { get; set; }
        public int IdMiembro { get; set; }
        public string NombreMiembro { get; set; }
        public int? IdCoach { get; set; }
        public string NombreCoach { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Descripcion { get; set; }
        public int? CarbohidratosDiarios { get; set; }
        public int? CaloriasDiarias { get; set; }
        public int? ProteinasDiarias { get; set; }
        public int? GrasasTotales { get; set; }
    }
}
