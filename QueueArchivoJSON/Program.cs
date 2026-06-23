using System;
using System.Collections.Generic;
using System.IO;          // Para manejar archivos (File.Exists, File.WriteAllText, etc.)
using System.Text.Json;    // Para serializar y deserializar JSON

class Program
{
    // Definimos el nombre del archivo como una constante
    private static readonly string ArchivoJson = "listaLavadero.json";

    static void Main(string[] args)
    {
        // Inicializamos la cola cargando los datos previos (si existen)
        Queue<Auto> filaEstacion = CargarDatos();
        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("=== ESTACIÓN DE SERVICIO (CON PERSISTENCIA JSON) ===");
            Console.WriteLine("1. Registrar llegada de auto (Encolar y Guardar)");
            Console.WriteLine("2. Atender auto (Desencolar y Guardar)");
            Console.WriteLine("3. Mostrar cantidad de autos en espera");
            Console.WriteLine("4. Mostrar lista de autos en espera");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese la patente: ");
                    string patente = Console.ReadLine()??"";
                    Console.Write("Ingrese el tipo de combustible: ");
                    string combustible = Console.ReadLine()??"";
                    
                    Auto nuevoAuto = new Auto(patente, combustible);
                    filaEstacion.Enqueue(nuevoAuto);
                    
                    // Guardamos el estado actual en el archivo
                    GuardarDatos(filaEstacion);
                    Console.WriteLine("\nAuto registrado y guardado en JSON con éxito.");
                    break;

                case "2":
                    if (filaEstacion.Count > 0)
                    {
                        Auto autoAtendido = filaEstacion.Dequeue();
                        
                        // Como la cola cambió, actualizamos el archivo inmediatamente
                        GuardarDatos(filaEstacion);
                        Console.WriteLine($"\nAtendiendo al auto -> {autoAtendido}");
                    }
                    else
                    {
                        Console.WriteLine("\nNo hay autos en la fila.");
                    }
                    break;

                case "3":
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

    // ==========================================
    // MÉTODOS DE PERSISTENCIA
    // ==========================================

    private static void GuardarDatos(Queue<Auto> cola)
    {
        try
        {
            // Convertimos la cola a un Array temporal para serializarla limpiamente
            Auto[] datosParaGuardar = cola.ToArray();
            
            // Opcional: WriteIndented hace que el JSON sea legible para humanos
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(datosParaGuardar, opciones);
            
            // Escribe el archivo en la carpeta del ejecutable (bin/Debug/net...)
            File.WriteAllText(ArchivoJson, jsonString);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError al guardar los datos: {ex.Message}");
        }
    }

    private static Queue<Auto> CargarDatos()
    {
        // Si el archivo no existe, significa que es la primera vez que corre, devolvemos cola vacía
        if (!File.Exists(ArchivoJson))
        {
            return new Queue<Auto>();
        }

        try
        {
            string jsonString = File.ReadAllText(ArchivoJson);
            
            // Deserializamos el JSON de vuelta a una lista de autos
            List<Auto> listaCargada = JsonSerializer.Deserialize<List<Auto>>(jsonString);

            if (listaCargada != null)
            {
                // El constructor de Queue acepta una colección y mete los elementos 
                // respetando exactamente el orden del índice (del 0 al final). FIFO garantizado.
                return new Queue<Auto>(listaCargada);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError al cargar el archivo JSON: {ex.Message}");
            Console.WriteLine("Se iniciará con una cola vacía. Presione una tecla para continuar...");
            Console.ReadKey();
        }

        return new Queue<Auto>();
    }
}