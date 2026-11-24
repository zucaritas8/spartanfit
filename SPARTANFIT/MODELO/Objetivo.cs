using System;

namespace SPARTANFIT.MODELO
{
    public class Objetivo
    {
        public int Id { get; set; }
        public int IdMiembro { get; set; }
        public string NombreMiembro { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public decimal? ValorInicial { get; set; }
        public decimal? ValorMeta { get; set; }
        public string Unidad { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
    }
}
