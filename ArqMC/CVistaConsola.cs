using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrimerEjemplo
{
    class CVistaConsola
    {
        public void MostrarMensaje(string msn)
        {
            Console.WriteLine(msn);
        }

        public string PedirTexto(string prompt)
        {
            string texto = null;
            Console.WriteLine(prompt);
            texto = Console.ReadLine();

            /*if (texto == null)
            {
                Console.WriteLine("El nombre no puede ser nulo.");
                Console.WriteLine(prompt);
                texto = Console.ReadLine();
            }*/
            

            return texto;
        }

        public float PedirFloat(string prompt)
        {
            float realSimple = 0.0f;
            Console.WriteLine(prompt);
            realSimple = float.Parse(Console.ReadLine());
            return realSimple;
        }
    }
}
