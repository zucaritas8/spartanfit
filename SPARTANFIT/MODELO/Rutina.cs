namespace SPARTANFIT.MODELO
{
    public class Rutina
    {
        public int Id { get; set; }
        public int IdCoach { get; set; }
        public string NombreCoach { get; set; }
        public string Nombre { get; set; }
        public int? Tiempo { get; set; }
        public string UnidadTiempo { get; set; }
        public string Descripcion { get; set; }
    }
}
