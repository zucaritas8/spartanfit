using System;

namespace SPARTANFIT.MODELO
{
    public class Coach
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string CI { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int? IdEspecialidad { get; set; }
        public string Especialidad { get; set; }
        public DateTime? FechaEmision { get; set; }
        public DateTime? FechaExpiracion { get; set; }
    }
}
