/*
Es la única clase que contiene Console.WriteLine y Console.ReadLine.
Se encarga exclusivamente de la interacción con el usuario.
*/
using System;
using System.Collections.Generic;

namespace GestionProductos
{
    public class Interfaz
    {
        public int MostrarMenu()
        {
            Console.WriteLine("\n--- SISTEMA DE GESTIÓN DE PRODUCTOS ---");
            Console.WriteLine("1. Agregar nuevo producto");
            Console.WriteLine("2. Listar todos los productos");
            Console.WriteLine("3. Buscar un producto por nombre");
            Console.WriteLine("4. Aplicar descuento a un producto");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            
            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                return opcion;
            }
            return 0; // Opción inválida
        }

        public string PedirTexto(string mensaje)
        {
            Console.Write(mensaje);
            return Console.ReadLine();
        }

        public double PedirNumero(string mensaje)
        {
            Console.Write(mensaje);
            if (double.TryParse(Console.ReadLine(), out double numero))
            {
                return numero;
            }
            return 0;
        }

        public void MostrarProductos(List<Especialista> productos)
        {
            Console.WriteLine("\n--- LISTA DE PRODUCTOS ---");
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos cargados.");
                return;
            }

            foreach (var p in productos)
            {
                Console.WriteLine($"- Nombre: {p.Nombre} | Precio: ${p.Precio:F2}");
            }
        }

        public void MostrarDetalleProducto(Especialista producto)
        {
            if (producto != null)
            {
                Console.WriteLine($"\n[Producto Encontrado] Nombre: {producto.Nombre} | Precio: ${producto.Precio:F2}");
            }
            else
            {
                Console.WriteLine("\n[Error] Producto no encontrado.");
            }
        }

        public void MostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
    }
}