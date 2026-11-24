using System;

namespace SPARTANFIT.MODELO
{
    public class Asistencia
    {
        public int Id { get; set; }
        public int IdInscripcion { get; set; }
        public int IdCredencial { get; set; }
        public string NombreMiembro { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraEntrada { get; set; }
    }
}
