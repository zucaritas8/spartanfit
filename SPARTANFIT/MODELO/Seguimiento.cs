using System;

namespace SPARTANFIT.MODELO
{
    public class Seguimiento
    {
        public int Id { get; set; }
        public int IdObjetivo { get; set; }
        public string DescripcionObjetivo { get; set; }
        public int? IdCoach { get; set; }
        public string NombreCoach { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public string Comentario { get; set; }
    }
}
