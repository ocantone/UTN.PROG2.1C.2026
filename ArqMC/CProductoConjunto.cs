using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrimerEjemplo
{
    class CProductoConjunto
    {
        private List<CProducto> listaProductos = new List<CProducto>();

        public void AgregarProducto(CProducto producto)
        {
            listaProductos.Add(producto);
        }

        public List<CProducto> ObtenerTodos()
        {
            return listaProductos;
        }

        public CProducto BuscarPorNombre(string nombre)
        {
            CProducto buscado = listaProductos.FirstOrDefault(p => p.Nombre == nombre);
            return buscado;
        }
    }
}
