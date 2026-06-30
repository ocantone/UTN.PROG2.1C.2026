/*
Una estación de servicio solo tiene una bomba de carga, por lo tanto los autos deben
esperar su turno para ser atendidos. Cada auto que llega se coloca al final de la fila,
y la atención se realiza en orden de llegada (FIFO). 
Crear un programa en C# que permita: 
Registrar autos que llegan a la estación (patente y tipo de combustible). 
Atender autos en orden de llegada. 
Mostrar la cantidad de autos esperando. 
Mostrar la lista de autos en espera. 
Utilizar una estructura Queue<Auto>. El sistema debe ofrecer un menú simple para interactuar con el usuario. 
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Queue<Auto> filaEstacion = new Queue<Auto>();
        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("=== ESTACIÓN DE SERVICIO ===");
            Console.WriteLine("1. Registrar llegada de auto (Encolar)");
            Console.WriteLine("2. Atender auto (Desencolar)");
            Console.WriteLine("3. Mostrar cantidad de autos en espera");
            Console.WriteLine("4. Mostrar lista de autos en espera");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese la patente: ");
                    string patente = Console.ReadLine();
                    Console.Write("Ingrese el tipo de combustible: ");
                    string combustible = Console.ReadLine();
                    
                    // Creamos el auto y lo metemos a la cola
                    Auto nuevoAuto = new Auto(patente, combustible);
                    filaEstacion.Enqueue(nuevoAuto);
                    
                    Console.WriteLine("\nAuto registrado con éxito.");
                    break;

                case "2":
                    // Validamos que haya autos para atender
                    if (filaEstacion.Count > 0)
                    {
                        // Dequeue saca al PRIMERO de la fila
                        Auto autoAtendido = filaEstacion.Dequeue();
                        Console.WriteLine($"\nAtendiendo al auto -> {autoAtendido}");
                    }
                    else
                    {
                        Console.WriteLine("\nNo hay autos en la fila.");
                    }
                    break;

                case "3":
                    // Count nos da el total de elementos
                    Console.WriteLine($"\nCantidad de autos esperando: {filaEstacion.Count}");
                    break;

                case "4":
                    Console.WriteLine("\n--- Autos en espera ---");
                    if (filaEstacion.Count == 0)
                    {
                        Console.WriteLine("La fila está vacía.");
                    }
                    else
                    {
                        // Podemos recorrer la cola con un foreach sin alterar el orden
                        foreach (var auto in filaEstacion)
                        {
                            Console.WriteLine(auto);
                        }
                    }
                    break;

                case "5":
                    salir = true;
                    Console.WriteLine("\nSaliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("\nOpción no válida. Intente de nuevo.");
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