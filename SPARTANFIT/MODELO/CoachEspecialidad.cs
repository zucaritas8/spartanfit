using System;

namespace SPARTANFIT.MODELO
{
    public class CoachEspecialidad
    {
        public int IdCoach { get; set; }
        public int IdEspecialidad { get; set; }
        public DateTime? FechaEmision { get; set; }
        public DateTime? FechaExpiracion { get; set; }
    }
}
