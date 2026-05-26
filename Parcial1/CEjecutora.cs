using System;
using System.Collections.Generic;

public class CEjecutora
{
    public static void Main(string[] args)
    {
        //Variables a utilizar
        float descuentoAnual;
        string codigo;
        string titulo;
        float costoBase;
        
        CRevista revistaMasEconomica = null;
        // Crear una lista para almacenar las revistas
        List<CRevista> revistas = new List<CRevista>();
        // Solicitar y establecer el valor del descuento anual
        Console.Write("Ingrese el porcentaje de descuento anual: ");
        descuentoAnual = float.Parse(Console.ReadLine());
        // Iterativamente solicitar y registrar los datos de las revistas
        Console.Write("Ingrese el código de la revista (o 'FIN' para terminar): ");
        codigo = Console.ReadLine().ToUpper();
        while (codigo != "FIN")
        {
            Console.Write("Ingrese el título de la revista: ");
            titulo = Console.ReadLine();
            Console.Write("Ingrese el costo base mensual de la revista: ");
            costoBase = float.Parse(Console.ReadLine());
            // Crear una nueva instancia de CRevista y agregarla a la lista
            CRevista revista = new CRevista(codigo, titulo);
            revista.SetCostoBase(costoBase);
            revistas.Add(revista);
            // Revista Mas Economica.
            if (revistaMasEconomica == null)
            {
                revistaMasEconomica = revista;
            }
            else
            {
                if (revista.MasBarata(revistaMasEconomica))
                {
                    revistaMasEconomica = revista;
                }
            }
            Console.Write("Ingrese el código de la revista (o 'FIN' para terminar): ");
            codigo = Console.ReadLine().ToUpper();
        }
        // Informar los datos de la revista más económica en modalidad anual
        if (revistaMasEconomica != null)
        {
            Console.WriteLine("Revista más económica en modalidad anual:");
            Console.WriteLine(revistaMasEconomica.DarDatos());
        }
        else
        {
            Console.WriteLine("No se ingresaron revistas.");
        }
        // Informar el total recaudado por todas las revistas
        float totalRecaudado = CRevista.TotalRecaudado(revistas);
        Console.WriteLine($"Total recaudado por suscripciones anuales: {totalRecaudado}");
    }
}