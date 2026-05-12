using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace EjemploListasAlumnos
{
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
            // Definimos el nombre del archivo aquí
            string nombreArchivo = "alumnos.json";

            // Pasamos 'nombreArchivo' como argumento
            List<Alumno> listaAlumnos = CargarDesdeArchivo(nombreArchivo);

            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("--- SISTEMA DE GESTIÓN DE ALUMNOS ---");
                Console.WriteLine("1. Ver lista de alumnos");
                Console.WriteLine("2. Cargar nuevo alumno");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MostrarAlumnos(listaAlumnos);
                        Console.WriteLine("\nPresione una tecla para volver...");
                        Console.ReadKey();
                        break;
                    case "2":
                        CargarUnAlumno(listaAlumnos);
                        // Pasamos el argumento también al guardar
                        GuardarEnArchivo(listaAlumnos, nombreArchivo); 
                        break;
                    case "3":
                        salir = true;
                        break;
                }
            }
        }

        // --- FUNCIONES CON PARÁMETROS DE RUTA ---

        // Ahora recibe 'rutaArchivo' como string
        static void GuardarEnArchivo(List<Alumno> lista, string rutaArchivo)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(rutaArchivo, jsonString);
                Console.WriteLine($"\n¡Datos guardados en {rutaArchivo}!");
                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar: {ex.Message}");
            }
        }

        // Ahora recibe 'rutaArchivo' como string
        static List<Alumno> CargarDesdeArchivo(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
            {
                return new List<Alumno>();
            }

            try
            {
                string jsonString = File.ReadAllText(rutaArchivo);
                return JsonSerializer.Deserialize<List<Alumno>>(jsonString);
            }
            catch (Exception)
            {
                return new List<Alumno>();
            }
        }

        static void CargarUnAlumno(List<Alumno> lista)
        {
            Alumno nuevoAlumno = new Alumno();
            Console.WriteLine("\n--- Carga de Nuevo Alumno ---");
            Console.Write("Nombre: ");
            nuevoAlumno.Nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            nuevoAlumno.Apellido = Console.ReadLine();
            Console.Write("Legajo: ");
            if (int.TryParse(Console.ReadLine(), out int legajo))
                nuevoAlumno.Legajo = legajo;

            lista.Add(nuevoAlumno);
        }

        static void MostrarAlumnos(List<Alumno> lista)
        {
            if (lista == null || lista.Count == 0)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }
            Console.WriteLine("\n" + $"{"Legajo",-10} | {"Apellido",-15} | {"Nombre",-15}");
            Console.WriteLine(new string('-', 45));
            foreach (var alumno in lista)
            {
                Console.WriteLine($"{alumno.Legajo,-10} | {alumno.Apellido,-15} | {alumno.Nombre,-15}");
            }
        }
    }
}