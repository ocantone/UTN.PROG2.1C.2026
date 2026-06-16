using System;
using System.Collections.Generic;
using ListaBDAlumnos.Models;

namespace ListaBDAlumnos.Views
{
    public class AlumnoView
    {
        public void MostrarListado(List<Alumno> alumnos)
        {
            Console.Clear();
            Console.WriteLine("==========================================================================================================");
            Console.WriteLine("                                           LISTADO DE ALUMNOS (PATRÓN MVC)                                ");
            Console.WriteLine("==========================================================================================================");
            Console.WriteLine(string.Format("{0,-10} | {1,-12} | {2,-12} | {3,-32} | {4,-22} | {5,-10}", 
                "Legajo", "Nombre", "Apellido", "Email", "Carrera", "Turno"));
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");

            foreach (var alumno in alumnos)
            {
                Console.WriteLine(string.Format("{0,-10} | {1,-12} | {2,-12} | {3,-32} | {4,-22} | {5,-10}", 
                    alumno.Legajo, alumno.Nombre, alumno.Apellido, alumno.Email, alumno.Carrera, alumno.Turno));
            }
            
            Console.WriteLine("==========================================================================================================\n");
        }

        public void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n⚠️ [ERROR EN SISTEMA]: {mensaje}\n");
            Console.ResetColor();
        }
    }
}