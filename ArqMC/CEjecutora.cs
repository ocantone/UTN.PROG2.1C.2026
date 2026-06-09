using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrimerEjemplo
{
    class CEjecutora
    {
        public static void Main()
        {
            //Prueba de la Consola:
            /*
            var vista = new CVistaConsola();
            string nombre = vista.PedirTexto("Ingrese su nombre");
            vista.MostrarMensaje($"Hola, {nombre}!");
            */
            
            //Prueba Clase Controladora
            var vista = new CVistaConsola();
            var conjunto = new CProductoConjunto();
            var contraolador = new CProductoControladora(vista, conjunto);

            contraolador.ListarProductos();
            contraolador.CrearProducto();
            contraolador.ListarProductos();

            //Prueba Clase Conjunto.
            /*
            var conjunto = new CProductoConjunto();
            conjunto.AgregarProducto(new CProducto("Mouse", 1200));
            var prod = conjunto.BuscarPorNombre("Mouse");
            Console.WriteLine(prod?.Nombre);  // Output: Mouse
            */

            //Prueba Clase Especialista
            /*
            var p = new Producto("Teclado", 3000);
            p.AplicarDescuento(10);
            Console.WriteLine(p.Precio);  // Output: 2700
            */

            Console.WriteLine("Precione <ENTER> para salir");
            Console.ReadLine();
        }
    }
}
