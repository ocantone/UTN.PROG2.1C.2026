using System;

namespace GestionProductos
{
    // Representa un producto individual
    public class Especialista
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public Especialista(string nombre, double precio)
        {
            Nombre = nombre;
            Precio = precio;
        }

        // Permite aplicar un descuento (ej: 10 para el 10%)
        public void AplicarDescuento(double porcentaje)
        {
            if (porcentaje > 0 && porcentaje <= 100)
            {
                Precio -= Precio * (porcentaje / 100);
            }
        }
    }
}