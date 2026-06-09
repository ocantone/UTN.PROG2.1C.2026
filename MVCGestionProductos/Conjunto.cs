/*
Conjunto.cs: Mantenemos y administramos la lista en memoria de los productos.
No "sabe nada" de la consola ni de cómo se muestran los datos.
*/
using System;
using System.Collections.Generic;

namespace GestionProductos
{
    // Administra la lista de productos
    public class Conjunto
    {
        private List<Especialista> listaProductos;

        public Conjunto()
        {
            listaProductos = new List<Especialista>();
        }

        public void AgregarProducto(Especialista producto)
        {
            listaProductos.Add(producto);
        }

        public List<Especialista> ObtenerTodos()
        {
            return listaProductos;
        }

        // Busca por nombre (ignora mayúsculas/minúsculas)
        public Especialista BuscarPorNombre(string nombre)
        {
            return listaProductos.Find(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }
    }
}