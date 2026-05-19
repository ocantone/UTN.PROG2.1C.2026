using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    // Ahora es una variable que define el archivo activo de la sesión
    private static string archivoActivo = "listaLavadero.json";

    static void Main(string[] args)
    {
        // Al arrancar, intentamos cargar desde el archivo activo por defecto
        Queue<Auto> filaEstacion = CargarDatos(archivoActivo);
        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("=== ESTACIÓN DE SERVICIO PRO (Estilo Cisco IOS) ===");
            Console.WriteLine($"[Archivo Activo: {archivoActivo}]");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("1. Registrar llegada de auto (Encolar)");
            Console.WriteLine("2. Atender auto (Desencolar)");
            Console.WriteLine("3. Mostrar cantidad de autos en espera");
            Console.WriteLine("4. Mostrar lista de autos en espera");
            Console.WriteLine("5. Cargar desde un archivo (.json)");
            Console.WriteLine("6. Guardar como / Cambiar archivo activo");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");
            
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese la patente: ");
                    string patente = Console.ReadLine();
                    Console.Write("Ingrese el tipo de combustible: ");
                    string combustible = Console.ReadLine();
                    
                    filaEstacion.Enqueue(new Auto(patente, combustible));
                    
                    // Auto-guardado en el archivo activo actual
                    GuardarDatos(filaEstacion, archivoActivo);
                    Console.WriteLine($"\nAuto registrado y guardado en '{archivoActivo}'");
                    break;

                case "2":
                    if (filaEstacion.Count > 0)
                    {
                        Auto autoAtendido = filaEstacion.Dequeue();
                        GuardarDatos(filaEstacion, archivoActivo);
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
                    // FEATURE: Cargar archivo
                    Console.Write($"Cargar archivo [{archivoActivo}]: ");
                    string entradaCargar = Console.ReadLine().Trim();
                    
                    // Si presionó Enter, usamos el activo. Si escribió algo, usamos ese.
                    string archivoACargar = string.IsNullOrEmpty(entradaCargar) ? archivoActivo : AsegurarExtensionJson(entradaCargar);

                    if (File.Exists(archivoACargar))
                    {
                        filaEstacion = CargarDatos(archivoACargar);
                        archivoActivo = archivoACargar; // El archivo cargado pasa a ser el activo
                        Console.WriteLine($"\nEstructura cargada con éxito desde '{archivoActivo}'.");
                    }
                    else
                    {
                        Console.WriteLine($"\nError: El archivo '{archivoACargar}' no existe.");
                    }
                    break;

                case "6":
                    // FEATURE: Guardar como (Cambiar destino)
                    // Quitamos el .json para mostrar el default limpio en el prompt
                    string nombreBaseDefault = archivoActivo.Replace(".json", "");
                    Console.Write($"Guardar como [{nombreBaseDefault}]: ");
                    string entradaGuardar = Console.ReadLine().Trim();

                    if (!string.IsNullOrEmpty(entradaGuardar))
                    {
                        // Si ingresó un nuevo nombre, actualizamos el archivo activo
                        archivoActivo = AsegurarExtensionJson(entradaGuardar);
                    }
                    
                    // Guardamos la cola actual en el (nuevo o viejo) archivo activo
                    GuardarDatos(filaEstacion, archivoActivo);
                    Console.WriteLine($"\nConfiguración guardada en el archivo activo: '{archivoActivo}'");
                    break;

                case "7":
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
    // MÉTODOS DE PERSISTENCIA MODIFICADOS
    // ==========================================

    private static void GuardarDatos(Queue<Auto> cola, string rutaArchivo)
    {
        try
        {
            Auto[] datosParaGuardar = cola.ToArray();
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(datosParaGuardar, opciones);
            
            File.WriteAllText(rutaArchivo, jsonString);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError al guardar en '{rutaArchivo}': {ex.Message}");
        }
    }

    private static Queue<Auto> CargarDatos(string rutaArchivo)
    {
        if (!File.Exists(rutaArchivo))
        {
            return new Queue<Auto>();
        }

        try
        {
            string jsonString = File.ReadAllText(rutaArchivo);
            List<Auto> listaCargada = JsonSerializer.Deserialize<List<Auto>>(jsonString);

            if (listaCargada != null)
            {
                return new Queue<Auto>(listaCargada);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError al cargar '{rutaArchivo}': {ex.Message}");
            Console.ReadKey();
        }

        return new Queue<Auto>();
    }

    // Método auxiliar para evitar que el usuario olvide poner ".json"
    private static string AsegurarExtensionJson(string nombreArchivo)
    {
        if (!nombreArchivo.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
        {
            return nombreArchivo + ".json";
        }
        return nombreArchivo;
    }
}