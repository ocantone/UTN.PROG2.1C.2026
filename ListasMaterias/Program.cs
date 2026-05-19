/******************************************
Ejercicio 3 – List: Materias de la carrera 
Enunciado: 
Crear un programa que permita almacenar en una List nombres de materias de una carrera.
El sistema debe permitir: 
Agregar materias. 
Eliminar una materia por nombre. 
Mostrar todas las materias cargadas. 
Verificar si una materia existe. 
Mostrar la cantidad de materias. 
********************************************/
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> materias = new List<string>();
        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("=== GESTIÓN DE MATERIAS DE LA CARRERA ===");
            Console.WriteLine("1. Agregar materia");
            Console.WriteLine("2. Eliminar materia por nombre");
            Console.WriteLine("3. Mostrar todas las materias");
            Console.WriteLine("4. Verificar si una materia existe");
            Console.WriteLine("5. Mostrar cantidad total de materias");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el nombre de la materia: ");
                    string nuevaMateria = Console.ReadLine();
                    
                    // Validamos que no metan un texto vacío
                    if (!string.IsNullOrWhiteSpace(nuevaMateria))
                    {
                        materias.Add(nuevaMateria);
                        Console.WriteLine($"\n'{nuevaMateria}' agregada correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("\nEl nombre no puede estar vacío.");
                    }
                    break;

                case "2":
                    Console.Write("Ingrese el nombre de la materia a eliminar: ");
                    string materiaAEliminar = Console.ReadLine();

                    // Remove() busca el elemento y lo borra. Devuelve true si lo encontró y eliminó.
                    if (materias.Remove(materiaAEliminar))
                    {
                        Console.WriteLine($"\nMateria '{materiaAEliminar}' eliminada con éxito.");
                    }
                    else
                    {
                        Console.WriteLine("\nNo se encontró la materia con ese nombre exacto.");
                    }
                    break;

                case "3":
                    Console.WriteLine("\n--- Lista de Materias Cargadas ---");
                    if (materias.Count == 0)
                    {
                        Console.WriteLine("No hay materias registradas aún.");
                    }
                    else
                    {
                        foreach (string mat in materias)
                        {
                            Console.WriteLine($"- {mat}");
                        }
                    }
                    break;

                case "4":
                    Console.Write("Ingrese la materia que desea buscar: ");
                    string materiaBuscar = Console.ReadLine();

                    // Contains() devuelve un booleano si encuentra coincidencia exacta
                    if (materias.Contains(materiaBuscar))
                    {
                        Console.WriteLine($"\nSí, la materia '{materiaBuscar}' ya está en el sistema.");
                    }
                    else
                    {
                        Console.WriteLine($"\nNo se encontró '{materiaBuscar}' en la lista.");
                    }
                    break;

                case "5":
                    Console.WriteLine($"\nCantidad total de materias: {materias.Count}");
                    break;

                case "6":
                    salir = true;
                    Console.WriteLine("\nSaliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("\nOpción no válida.");
                    break;
            }

            if (!salir)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}