/*===============================================================================
PROGRAMACIÓN III Conexión a MySQL (Enfoque MVC).
 
 ⚠️ Antes de correr el proyecto, se debe instalar el driver de MySQL.
 Ejecutar este comando:
 dotnet add package MySql.Data --source https://api.nuget.org/v3/index.json
===============================================================================*/


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