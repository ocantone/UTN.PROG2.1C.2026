using System;

namespace ListaBDAlumnos.Models
{
    public class Alumno
    {
        public int Legajo { get; set; }
        /*Inicializamos con valores por defecto para evitar posibles
        null references, que generan Warning */
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Carrera { get; set; } = string.Empty;
        public string Turno { get; set; } = string.Empty;
        public DateTime FechaInscripcion { get; set; }
    }
}