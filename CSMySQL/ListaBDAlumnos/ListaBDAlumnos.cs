/*===============================================================================
PROGRAMACIÓN III Conexión Lineal a MySQL 
 
 ⚠️ Antes de correr el proyecto, se debe instalar el driver de MySQL.
 En VSCode ejecutar este comando por terminal:
 dotnet add package MySql.Data --source https://api.nuget.org/v3/index.json
En Visual Studio (Comunity, etc):
Ir a: Herramientas > Administrador de Paquetes NuGet > Administrar paquetes NuGet > MyDql.Data
===============================================================================*/
using System;
// Importamos los componentes del driver de MySQL.
using MySqlConnection = MySql.Data.MySqlClient.MySqlConnection;
using MySqlCommand = MySql.Data.MySqlClient.MySqlCommand;
using MySqlDataReader = MySql.Data.MySqlClient.MySqlDataReader;

namespace ListaBDAlumnos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cadena de conexión.
            string connectionString = "Server=localhost;Port=3306;Database=miBD;Uid=root;Pwd=root;";
            Console.WriteLine("Intentando conectar a la base de datos MySQL...");
            // Abrimos la conexión asegurando el cierre de recursos con 'using'.
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            { //conexion es un OJETO que prepara el canal TCP para conectar al servidor MySql.
                try
                {
                    conexion.Open(); //Aquí es dónde la conexión se abre. (Se cierra gracias a using)
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("¡Conexión exitosa al servidor de MySQL!\n");
                    Console.ResetColor();

                    // Sentencia SQL pura para interactuar con la BD
           string consulta = "SELECT legajo, nombre, apellido, email, carrera, turno FROM alumnos";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        using (MySqlDataReader lector = comando.ExecuteReader())
                        {
                            Console.WriteLine("==========================================================================================================");
                            Console.WriteLine("                                           LISTADO DE ALUMNOS (LINEAL)                                    ");
                            Console.WriteLine("==========================================================================================================");
                            Console.WriteLine(string.Format("{0,-10} | {1,-12} | {2,-12} | {3,-32} | {4,-22} | {5,-8}", 
                                "Legajo", "Nombre", "Apellido", "Email", "Carrera", "Turno"));
                            Console.WriteLine("----------------------------------------------------------------------------------------------------------");

                            // Bloque iterativo: leemos fila por fila mientras el lector tenga datos
                            while (lector.Read())
                            {
                                string legajo = lector["legajo"].ToString()??"";
                                string nombre = lector["nombre"].ToString()??"";
                                string apellido = lector["apellido"].ToString()??"";
                                string email = lector["email"].ToString()??"";
                                string carrera = lector["carrera"].ToString()??"";
                                string turno = lector["turno"].ToString()??"";

                                Console.WriteLine(string.Format("{0,-10} | {1,-12} | {2,-12} | {3,-32} | {4,-22} | {5,-8}", 
                                    legajo, nombre, apellido, email, carrera, turno));
                            }
                            Console.WriteLine("==========================================================================================================\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Control de errores ante fallas de red, credenciales o servidor apagado
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ocurrió un error al intentar operar con la base de datos:");
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }

            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}