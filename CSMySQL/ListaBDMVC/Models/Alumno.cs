using System;

namespace ListaBDAlumnos.Models
{
    public class Alumno
    {
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Carrera { get; set; }
        public string Turno { get; set; }
        public DateTime FechaInscripcion { get; set; }
    }
}