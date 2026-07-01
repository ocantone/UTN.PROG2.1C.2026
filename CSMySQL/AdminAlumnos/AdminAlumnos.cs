/*===============================================================================
PROGRAMACIÓN III - Administración de Alumnos (CRUD con MySQL)
===============================================================================*/
using System;
using MySqlConnection = MySql.Data.MySqlClient.MySqlConnection;
using MySqlCommand = MySql.Data.MySqlClient.MySqlCommand;
using MySqlDataReader = MySql.Data.MySqlClient.MySqlDataReader;

namespace AdminAlumnos
{
    class Program
    {
        // Compartimos la cadena de conexión para reutilizarla en los distintos métodos
        private static string connectionString = "Server=localhost;Port=3306;Database=miBD;Uid=root;Pwd=root;";

        static void Main(string[] args)
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("==================================================");
                Console.WriteLine("          SISTEMA DE GESTIÓN DE ALUMNOS           ");
                Console.WriteLine("==================================================");
                Console.WriteLine("1. Listar todos los alumnos");
                Console.WriteLine("2. Ver un alumno por Legajo");
                Console.WriteLine("3. Agregar un nuevo alumno");
                Console.WriteLine("4. Eliminar un alumno");
                Console.WriteLine("5. Salir");
                Console.WriteLine("==================================================");
                Console.Write("Seleccione una opción: ");
                
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ListarAlumnos();
                        break;
                    case "2":
                        VerAlumno();
                        break;
                    case "3":
                        AgregarAlumno();
                        break;
                    case "4":
                        EliminarAlumno();
                        break;
                    case "5":
                        salir = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nOpción no válida. Intente nuevamente.");
                        Console.ResetColor();
                        PresionarTecla();
                        break;
                }
            }
        }

        // 1. LISTAR TODOS LOS ALUMNOS
        static void ListarAlumnos()
        {
            Console.Clear();
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT legajo, nombre, apellido, email, carrera, turno FROM alumnos";

                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        using (MySqlDataReader lector = comando.ExecuteReader())
                        {
                            Console.WriteLine("==========================================================================================================");
                            Console.WriteLine("                                           LISTADO DE ALUMNOS                                             ");
                            Console.WriteLine("==========================================================================================================");
                            Console.WriteLine(string.Format("{0,-10} | {1,-12} | {2,-12} | {3,-32} | {4,-22} | {5,-8}", 
                                "Legajo", "Nombre", "Apellido", "Email", "Carrera", "Turno"));
                            Console.WriteLine("----------------------------------------------------------------------------------------------------------");

                            while (lector.Read())
                            {
                                string legajo = lector["legajo"].ToString() ?? "";
                                string nombre = lector["nombre"].ToString() ?? "";
                                string apellido = lector["apellido"].ToString() ?? "";
                                string email = lector["email"].ToString() ?? "";
                                string carrera = lector["carrera"].ToString() ?? "";
                                string turno = lector["turno"].ToString() ?? "";

                                Console.WriteLine(string.Format("{0,-10} | {1,-12} | {2,-12} | {3,-32} | {4,-22} | {5,-8}", 
                                    legajo, nombre, apellido, email, carrera, turno));
                            }
                            Console.WriteLine("==========================================================================================================\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MostrarError(ex.Message);
                }
            }
            PresionarTecla();
        }

        // 2. VER UN ALUMNO (Por Legajo)
        static void VerAlumno()
        {
            Console.Clear();
            Console.WriteLine("=== VER DETALLE DE ALUMNO ===");
            Console.Write("Ingrese el legajo del alumno a buscar: ");
            string legajoBuscar = Console.ReadLine();

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    // Usamos parámetros (@legajo) para evitar SQL Injection, una buena práctica clave
                    string query = "SELECT legajo, nombre, apellido, email, carrera, turno FROM alumnos WHERE legajo = @legajo";

                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@legajo", legajoBuscar);

                        using (MySqlDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("\n--------------------------------------------------");
                                Console.WriteLine($"Legajo:    {lector["legajo"]}");
                                Console.WriteLine($"Nombre:    {lector["nombre"]}");
                                Console.WriteLine($"Apellido:  {lector["apellido"]}");
                                Console.WriteLine($"Email:     {lector["email"]}");
                                Console.WriteLine($"Carrera:   {lector["carrera"]}");
                                Console.WriteLine($"Turno:     {lector["turno"]}");
                                Console.WriteLine("--------------------------------------------------");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"\nNo se encontró ningún alumno con el legajo: {legajoBuscar}");
                                Console.ResetColor();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MostrarError(ex.Message);
                }
            }
            PresionarTecla();
        }

        // 3. AGREGAR UN ALUMNO
        static void AgregarAlumno()
        {
            Console.Clear();
            Console.WriteLine("=== AGREGAR NUEVO ALUMNO ===");
            
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Carrera: ");
            string carrera = Console.ReadLine();
            Console.Write("Turno: ");
            string turno = Console.ReadLine();

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    string query = "INSERT INTO alumnos (nombre, apellido, email, carrera, turno) VALUES (@nombre, @apellido, @email, @carrera, @turno)";

                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        // Parametrización de los datos de entrada
                        comando.Parameters.AddWithValue("@nombre", nombre);
                        comando.Parameters.AddWithValue("@apellido", apellido);
                        comando.Parameters.AddWithValue("@email", email);
                        comando.Parameters.AddWithValue("@carrera", carrera);
                        comando.Parameters.AddWithValue("@turno", turno);

                        // Al no ser una consulta de selección, usamos ExecuteNonQuery
                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n¡Alumno agregado exitosamente!");
                            Console.ResetColor();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MostrarError(ex.Message);
                }
            }
            PresionarTecla();
        }

        // 4. ELIMINAR UN ALUMNO
        static void EliminarAlumno()
        {
            Console.Clear();
            Console.WriteLine("=== ELIMINAR ALUMNO ===");
            Console.Write("Ingrese el legajo del alumno que desea eliminar: ");
            string legajoEliminar = Console.ReadLine();

            // Confirmación de seguridad
            Console.Write($"¿Está seguro que desea eliminar al alumno con legajo {legajoEliminar}? (S/N): ");
            string confirmacion = Console.ReadLine();

            if (confirmacion.Trim().ToUpper() != "S")
            {
                Console.WriteLine("\nOperación cancelada.");
                PresionarTecla();
                return;
            }

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    string query = "DELETE FROM alumnos WHERE legajo = @legajo";

                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@legajo", legajoEliminar);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n¡Alumno eliminado correctamente de la base de datos!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"\nNo se afectó ninguna fila. El legajo {legajoEliminar} podría no existir.");
                            Console.ResetColor();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MostrarError(ex.Message);
                }
            }
            PresionarTecla();
        }

        // Métodos auxiliares para evitar repetir código de interfaz de usuario
        static void PresionarTecla()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nOcurrió un error al intentar operar con la base de datos:");
            Console.WriteLine(mensaje);
            Console.ResetColor();
        }
    }
}