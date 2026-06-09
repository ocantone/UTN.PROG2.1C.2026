using System;

namespace GestionProductos
{
    public class Controladora
    {
        private Interfaz vista;
        private Conjunto modelo;

        public Controladora(Interfaz interfaz, Conjunto conjunto)
        {
            vista = interfaz;
            modelo = conjunto;
        }

        public void Iniciar()
        {
            int opcion = 0;
            do
            {
                opcion = vista.MostrarMenu();
                ProcesarOpcion(opcion);
            } while (opcion != 5);
        }

        private void ProcesarOpcion(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    string nombre = vista.PedirTexto("Ingrese nombre del producto: ");
                    double precio = vista.PedirNumero("Ingrese precio del producto: ");
                    
                    Especialista nuevoProducto = new Especialista(nombre, precio);
                    modelo.AgregarProducto(nuevoProducto);
                    vista.MostrarMensaje("[Éxito] Producto agregado correctamente.");
                    break;

                case 2:
                    var productos = modelo.ObtenerTodos();
                    vista.MostrarProductos(productos);
                    break;

                case 3:
                    string busqueda = vista.PedirTexto("Ingrese el nombre a buscar: ");
                    Especialista encontrado = modelo.BuscarPorNombre(busqueda);
                    vista.MostrarDetalleProducto(encontrado);
                    break;

                case 4:
                    string prodDescuento = vista.PedirTexto("Ingrese el nombre del producto a descontar: ");
                    Especialista pDescuento = modelo.BuscarPorNombre(prodDescuento);
                    
                    if (pDescuento != null)
                    {
                        double porc = vista.PedirNumero("Ingrese el porcentaje de descuento (0-100): ");
                        pDescuento.AplicarDescuento(porc);
                        vista.MostrarMensaje($"[Éxito] Descuento aplicado. Nuevo precio: ${pDescuento.Precio:F2}");
                    }
                    else
                    {
                        vista.MostrarMensaje("[Error] Producto no encontrado.");
                    }
                    break;

                case 5:
                    vista.MostrarMensaje("Saliendo del sistema. ¡Hasta luego!");
                    break;

                default:
                    vista.MostrarMensaje("[Opción Inválida] Intente nuevamente.");
                    break;
            }
        }
    }
}