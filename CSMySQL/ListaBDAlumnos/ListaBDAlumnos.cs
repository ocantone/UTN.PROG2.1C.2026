/*===============================================================================
 PROGRAMACIÓN II: Acceso a Base de Datos con C# y MySQL.
 Conexión a MySQL y listado de alumnos desde la consola.
 
 ⚠️ Antes de correr el proyecto, se debe instalar el driver de MySQL.
 Para ello ejecutar el siguiente comando en la terminal de VS Code:
 
 dotnet add package MySql.Data --source https://api.nuget.org/v3/index.json
===============================================================================*/
using System;
using MySqlConnection = MySql.Data.MySqlClient.MySqlConnection;
using MySqlCommand = MySql.Data.MySqlClient.MySqlCommand;
using MySqlDataReader = MySql.Data.MySqlClient.MySqlDataReader;

string connectionString = "Server=localhost;Port=3306;Database=miBD;Uid=root;Pwd=root;";

Console.WriteLine("Intentando conectar a la base de datos MySQL...");

using (MySqlConnection conexion = new MySqlConnection(connectionString))
{
    try
    {
        conexion.Open();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("¡Conexión exitosa al servidor de MySQL!\n");
        Console.ResetColor();

        // Consulta los campos de la tabla Alumnos de miBD.
        string query = "SELECT legajo, nombre, apellido, email, carrera, turno, fecha_inscripcion FROM alumnos";

        using (MySqlCommand comando = new MySqlCommand(query, conexion))
        {
            using (MySqlDataReader lector = comando.ExecuteReader())
            {
                Console.WriteLine("==========================================================================================================");
                Console.WriteLine("                                           LISTADO DE ALUMNOS                               ");
                Console.WriteLine("==========================================================================================================");
                // Ajustamos el formato de columnas para que entre toda la información
                Console.WriteLine(string.Format("{0,-10} | {1,-12} | {2,-12} | {3,-32} | {4,-22} | {5,-8}", 
                    "Legajo", "Nombre", "Apellido", "Email", "Carrera", "Turno"));
                Console.WriteLine("----------------------------------------------------------------------------------------------------------");

                while (lector.Read())
                {
                    // Extraemos los datos mapeando los tipos correspondientes de la BD
                    string legajo = lector["legajo"].ToString()??"";
                    string nombre = lector["nombre"].ToString()??"";
                    string apellido = lector["apellido"].ToString()??"";
                    string email = lector["email"].ToString()??"";
                    string carrera = lector["carrera"].ToString()??"";
                    string turno = lector["turno"].ToString()??"";

                    // Mostramos en consola
                    Console.WriteLine(string.Format("{0,-10} | {1,-12} | {2,-12} | {3,-32} | {4,-22} | {5,-8}", 
                        legajo, nombre, apellido, email, carrera, turno));
                }
                Console.WriteLine("==========================================================================================================\n");
            }
        }
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Ocurrió un error al intentar operar con la base de datos:");
        Console.WriteLine(ex.Message);
        Console.ResetColor();
    }
}

Console.WriteLine("Presione cualquier tecla para salir...");
Console.ReadKey();