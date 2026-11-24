namespace SPARTANFIT.MODELO
{
    public class EstacionEjercicio
    {
        public int IdEstacion { get; set; }
        public int IdEjercicio { get; set; }
        public string NombreEjercicio { get; set; }
        public int Orden { get; set; }
        public int? NumeroSeries { get; set; }
        public int? Repeticiones { get; set; }
        public string Tiempo { get; set; }
    }
}
