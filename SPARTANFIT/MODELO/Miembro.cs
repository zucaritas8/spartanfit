using System;

namespace SPARTANFIT.MODELO
{
    public class Miembro
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string CI { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public string NombreCompleto
        {
            get { return Nombre + " " + Apellidos; }
        }

        public int Edad
        {
            get
            {
                DateTime hoy = DateTime.Today;
                int edad = hoy.Year - FechaNacimiento.Year;
                if (FechaNacimiento.Date > hoy.AddYears(-edad)) edad--;
                return edad;
            }
        }
    }
}
