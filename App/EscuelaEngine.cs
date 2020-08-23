using Project_Carthage.Entidades;
using Project_Carthage.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Text;

namespace Project_Carthage
{
    public class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {
        }

        public void Inicializar()
        {

            Escuela = new Escuela("Academia Kadik", 1998, TiposEscuela.Secundaria,
            ciudad: "Boulogne-Billancourt", pais: "Francia");

            InicializarCursos();
            InicializarAsignaturas();
            InicializarEvaluaciones();
        }

        private void InicializarCursos()
        {
            Escuela.Cursos = new List<Curso>
            {
                new Curso(){Nombre = "Curso 101", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "Curso 201", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "Curso 301", Jornada = TiposJornada.Tarde},
                new Curso(){Nombre = "Curso 404", Jornada = TiposJornada.Tarde},
                new Curso(){Nombre = "Curso 504", Jornada = TiposJornada.Noche}
            };

            Random random = new Random();

            foreach (var curso in Escuela.Cursos)
            {
                int cantidadRandom = random.Next(15, 25);
                curso.Alumno = InicializarAlumnos(cantidadRandom);
            }
        }

        private void InicializarEvaluaciones()
        {
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var alumno in curso.Alumno)
                {
                    int contador = 0;

                    foreach (var asignatura in curso.Asignaturas)
                    {
                        contador++;

                        if (alumno.Evaluaciones == null)
                        {
                            alumno.Evaluaciones = new List<Evaluaciones>();
                        }

                        alumno.Evaluaciones.Add(new Evaluaciones
                        {
                            Asignatura = asignatura,
                            Nota = notaRandom(),
                            Nombre = $"Evaluación: {contador}"
                        });
                    }
                }
            }
        }

        private static float notaRandom()
        {
            Random rN = new Random();
            float resultado = (float) rN.NextDouble() * 10;

            return resultado;
        }

        private void InicializarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                List<Asignatura> listaAsignaturas = new List<Asignatura>() 
                { 
                    new Asignatura() {Nombre = "Francés"},
                    new Asignatura() {Nombre = "Español"},
                    new Asignatura() {Nombre = "Química"},
                    new Asignatura() {Nombre = "Matemáticas"},
                    new Asignatura() {Nombre = "E.F"}
                };

                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> InicializarAlumnos(int maxAlumnado)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno() { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy((alumno) => alumno.UniqueId).Take(maxAlumnado).ToList();
        }
    }
}
