namespace SPARTANFIT.MODELO
{
    public class RutinaEjercicio
    {
        public int IdRutina { get; set; }
        public int IdEjercicio { get; set; }
        public string NombreEjercicio { get; set; }
        public int? NumeroSeries { get; set; }
        public int Orden { get; set; }
        public int? Repeticiones { get; set; }
    }
}
