using Project_Carthage.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_Carthage
{
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }


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

        public List<ParentEntity> GetParentEntities()
        {
            List<ParentEntity> listaObj = new List<ParentEntity>();
            listaObj.Add(Escuela);
            listaObj.AddRange(Escuela.Cursos);

            foreach (var curso in Escuela.Cursos)
            {
                listaObj.AddRange(curso.Asignaturas);
                listaObj.AddRange(curso.Alumno);

                foreach (var alumno in curso.Alumno)
                {
                    listaObj.Add(alumno);

                }
            }

            return listaObj;
        }

        private void InicializarEvaluaciones()
        {
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var alumno in curso.Alumno)
                {
                    Evaluacion

                    int contador = 0;

                    foreach (var asignatura in curso.Asignaturas)
                    {
                        contador++;

                        if (alumno.Evaluaciones == null)
                        {
                            alumno.Evaluaciones = new List<Evaluacion>();
                        }

                        alumno.Evaluaciones.Add(new Evaluacion
                        {
                            evOwner = alumno,
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
            float resultado = (float)rN.NextDouble() * 10;

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
