using System;
using System.Collections.Generic;
using MySqlConnection = MySql.Data.MySqlClient.MySqlConnection;
using MySqlCommand = MySql.Data.MySqlClient.MySqlCommand;
using MySqlDataReader = MySql.Data.MySqlClient.MySqlDataReader;

namespace ListaBDAlumnos.Models
{
    public class AlumnoModel
    {
        private string connectionString = "Server=localhost;Port=3306;Database=miBD;Uid=root;Pwd=root;";

        public List<Alumno> ObtenerTodos()
        {
            List<Alumno> listaAlumnos = new List<Alumno>();
            string query = "SELECT legajo, nombre, apellido, email, carrera, turno, fecha_inscripcion FROM alumnos";

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            // Instanciamos un objeto Alumno por cada fila y lo agregamos a la lista
                            Alumno alumno = new Alumno
                            {
                                Legajo = Convert.ToInt32(lector["legajo"]),
                                Nombre = lector["nombre"].ToString()??"",
                                Apellido = lector["apellido"].ToString()??"",
                                Email = lector["email"].ToString()??"",
                                Carrera = lector["carrera"].ToString()??"",
                                Turno = lector["turno"].ToString()??"",
                                // Conversión explícita a tipo DateTime de C#
                                FechaInscripcion = Convert.ToDateTime(lector["fecha_inscripcion"])
                            };

                            listaAlumnos.Add(alumno);
                        }
                    }
                }
            }
            return listaAlumnos;
        }
    }
}