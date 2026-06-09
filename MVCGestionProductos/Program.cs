namespace GestionProductos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inicialización de los componentes
            Interfaz vista = new Interfaz();
            Conjunto modelo = new Conjunto();
            
            // Se inyectan en el controlador
            Controladora controlador = new Controladora(vista, modelo);
            
            // Arranca la aplicación
            controlador.Iniciar();
        }
    }
}