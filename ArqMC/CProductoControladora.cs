using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrimerEjemplo
{
    class CProductoControladora
    {
        private CVistaConsola vista;
        private CProductoConjunto productos;

        public CProductoControladora(CVistaConsola vista, CProductoConjunto productos)
        {
            this.vista = vista;
            this.productos = productos;
        }

        public void CrearProducto()
        {
            string nombre = vista.PedirTexto("Nombre del Producto");
            float precio = vista.PedirFloat("Precio del Producto");

            CProducto nuevo = new CProducto(nombre, precio);

            productos.AgregarProducto(nuevo);

            vista.MostrarMensaje("Producto creado correctamente.");
        }

        public void ListarProductos()
        {
            var lista = productos.ObtenerTodos();

            if (lista.Count == 0)
            {
                vista.MostrarMensaje("No Hay productos Cargados");
            }
            else
            {
                foreach (var p in lista)
                {
                    vista.MostrarMensaje(p.Nombre + ": $" + p.Precio);
                }

            }
        }
    }
}
