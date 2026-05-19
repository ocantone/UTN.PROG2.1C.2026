/*
Ejercicio 2 – Pila: Pila de libros en una biblioteca 
Enunciado: 
Una biblioteca almacena libros en una pila dentro de un mostrador de devolución.
Cada vez que un usuario devuelve un libro, se coloca en la parte superior de la pila.
Cuando el bibliotecario retira un libro para reubicarlo en estanterías, lo toma del tope. 
Crear un programa en C# que permita: 
Registrar la devolución de un libro (título y autor). 
Retirar el último libro devuelto. 
Ver el libro en el tope sin retirarlo. 
Mostrar todos los libros en la pila. 
Utilizar una estructura Stack<Libro> y diseñar el programa con buenas prácticas. 
*/
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Stack<Libro> pilaLibros = new Stack<Libro>();
        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("=== CONTROL DE DEVOLUCIONES (BIBLIOTECA) ===");
            Console.WriteLine("1. Registrar devolución de libro (Push)");
            Console.WriteLine("2. Retirar último libro devuelto (Pop)");
            Console.WriteLine("3. Ver libro en el tope (Peek)");
            Console.WriteLine("4. Mostrar todos los libros en la pila");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el título del libro: ");
                    string titulo = Console.ReadLine();
                    Console.Write("Ingrese el autor: ");
                    string autor = Console.ReadLine();

                    // Push agrega el elemento AL TOPE de la pila
                    pilaLibros.Push(new Libro(titulo, autor));
                    Console.WriteLine("\nLibro recibido y apilado.");
                    break;

                case "2":
                    if (pilaLibros.Count > 0)
                    {
                        // Pop remueve y devuelve el elemento del tope
                        Libro libroRetirado = pilaLibros.Pop();
                        Console.WriteLine($"\nRetirando para estantería: {libroRetirado}");
                    }
                    else
                    {
                        Console.WriteLine("\nNo hay libros en el mostrador.");
                    }
                    break;

                case "3":
                    if (pilaLibros.Count > 0)
                    {
                        // Peek solo MIRA el elemento de arriba, NO lo saca
                        Libro libroEnTope = pilaLibros.Peek();
                        Console.WriteLine($"\nLibro en el tope actual: {libroEnTope}");
                    }
                    else
                    {
                        Console.WriteLine("\nLa pila está vacía.");
                    }
                    break;

                case "4":
                    Console.WriteLine("\n--- Libros en la pila (desde el tope hacia la base) ---");
                    if (pilaLibros.Count == 0)
                    {
                        Console.WriteLine("No hay libros.");
                    }
                    else
                    {
                        // Al recorrer un Stack con foreach, C# lo muestra en orden LIFO automáticamente
                        foreach (var libro in pilaLibros)
                        {
                            Console.WriteLine(libro);
                        }
                    }
                    break;

                case "5":
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