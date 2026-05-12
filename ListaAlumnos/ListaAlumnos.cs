using System;
using System.Collections.Generic;

namespace EjemploListasAlumnos
{
    // 1. Definición de la clase Alumno
    public class Alumno
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Legajo { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creamos la lista de alumnos
            List<Alumno> listaAlumnos = new List<Alumno>();

            Console.WriteLine("--- Carga de Datos de Alumnos ---");
            
            // Llamamos a la función de carga pasándole la lista
            CargarAlumnos(listaAlumnos, 3);

            Console.WriteLine("\n--- Listado de Alumnos Registrados ---");
            
            // Llamamos a la función para mostrar los datos
            MostrarAlumnos(listaAlumnos);

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

        // 2. Función para cargar los datos de cada alumno
        static void CargarAlumnos(List<Alumno> lista, int cantidad)
        {
            for (int i = 0; i < cantidad; i++)
            {
                Alumno nuevoAlumno = new Alumno();

                Console.WriteLine($"\nAlumno {i + 1}:");
                
                Console.Write("Ingrese Nombre: ");
                nuevoAlumno.Nombre = Console.ReadLine();

                Console.Write("Ingrese Apellido: ");
                nuevoAlumno.Apellido = Console.ReadLine();

                Console.Write("Ingrese Legajo: ");
                // Validación básica para evitar errores si no ingresan un número
                if (int.TryParse(Console.ReadLine(), out int legajo))
                {
                    nuevoAlumno.Legajo = legajo;
                }
                else
                {
                    nuevoAlumno.Legajo = 0; 
                }

                lista.Add(nuevoAlumno);
            }
        }

        // 3. Función para mostrar los alumnos en pantalla
        static void MostrarAlumnos(List<Alumno> lista)
        {
            if (lista.Count == 0)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            // Encabezados simples
            Console.WriteLine($"{"Legajo",-10} | {"Apellido",-15} | {"Nombre",-15}");
            Console.WriteLine(new string('-', 45));

            foreach (var alumno in lista)
            {
                Console.WriteLine($"{alumno.Legajo,-10} | {alumno.Apellido,-15} | {alumno.Nombre,-15}");
            }
        }
    }
}