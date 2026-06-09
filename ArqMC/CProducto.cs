using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrimerEjemplo
{
    class CProducto
    {
        private string nombre;
        private float precio;
        public string Nombre
        {
            get { return this.nombre; }
            private set { this.nombre = value; }
        }
        public float Precio
        {
            get { return this.precio; }
            private set { this.precio = value; }
        }

        public CProducto(string nombre, float precio)
        {
            this.Nombre = nombre;
            this.Precio = precio;
        }

        public void AplicarDescuento(float porcentaje)
        {
            this.Precio -= this.Precio * (porcentaje / 100);
        }

    }
}
