/*
===============================================================================
 ACTIVIDAD INTEGRADORA: PROGRAMACIÓN II + PROGRAMACIÓN III
 CLASE 3: Punto de Entrada Principal estructurado en MVC
===============================================================================
*/

using System;
using ListaBDAlumnos.Models;
using ListaBDAlumnos.Views;
using ListaBDAlumnos.Controllers;

namespace ListaBDAlumnos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciamos los componentes de la arquitectura
            AlumnoModel modelo = new AlumnoModel();
            AlumnoView vista = new AlumnoView();
            
            // Inyección de dependencias básicas por constructor
            AlumnoController controlador = new AlumnoController(modelo, vista);

            // Iniciamos la acción del sistema
            controlador.EjecutarListado();

            Console.WriteLine("Presione cualquier tecla para finalizar el programa...");
            Console.ReadKey();
        }
    }
}