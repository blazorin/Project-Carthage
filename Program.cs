using Project_Carthage.Entidades;
using Project_Carthage.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using static System.Console;

namespace Project_Carthage
{
    class Program
    {
        static void Main(string[] args)
        {

            var engine = new EscuelaEngine();
            engine.Inicializar();

            //Predicate<Curso> miAlgoritmo = predicado;

            /*
            escuela.Cursos.RemoveAll(delegate (Curso cur) 
                                    {
                                       return cur.Nombre == "301";
                                    });

            escuela.Cursos.RemoveAll((cur) => cur.Nombre == "301" && cur.Jornada == TiposJornada.Mañana);
            */

            ImprimirCursosEscuela(engine.Escuela);
            Write($"Escuela: {engine.Escuela.TipoEscuela} \r\n");
            GetEstudiantes(engine.Escuela);
            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.WriteTitle("Pruebas de Polimorfismo");

            var alumnoTest = new Alumno { Nombre = "Teresa de Calcuta" };

            var parentEntities = engine.GetParentEntities(out int conteoEvaluaciones,
            out int conteoAsignaturas,
            out int ConteoAlumnos,
            out int ConteoCursos,
            true, true, true, true);

            foreach (var item in parentEntities)
            {
                /*
                if ((item as Alumno) != null)
                {
                    Write("SEX -> " + items.GetType());
                }
                */
            }

            var iLugarLista = from obj in parentEntities
                              where obj is iLugar
                              select (iLugar)obj;

            //engine.Escuela.LimpiarLugar();

        }


        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Academia Kadic");
            Printer.Beeep(10000, cantidad: 5);


            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre {curso.Nombre} , Id {curso.UniqueId}");
                }
            }
        }
        private static void GetEstudiantes(Escuela escuela)
        {
            foreach (var curso in escuela.Cursos)
            {
                Printer.WriteTitle(curso.Nombre);
                WriteLine("Tipo de Jornada: " + curso.Jornada);

                foreach (var alumno in curso.Alumno)
                {
                    Printer.WriteTitle(alumno.Nombre);

                    foreach (var evaluacion in alumno.Evaluaciones)
                    {
                        WriteLine($"{evaluacion.Nombre}\r\n{"Asignatura: " + evaluacion.Asignatura.Nombre}\r\n{"Nota: " + evaluacion.Nota}\r\n{"ID: " + evaluacion.UniqueId}");
                        WriteLine(new string('=', 10));
                    }
                }

            }
        }

        /*
        private static void ImprimirCursosWhile(List<Curso> arregloCursos)
        {
            int contador = 0;

            while (contador < arregloCursos.Count)
            {
                Console.WriteLine($"Nombre {arregloCursos[contador].Nombre} ," +
                    $" Id {arregloCursos[contador].UniqueId}");
                contador++;
            }
        }

        private static void ImprimirCursosDoWhile(Curso[] arregloCursos)
        {
            int contador = 0;
            do
            {
                Console.WriteLine($"Nombre {arregloCursos[contador].Nombre} ," +
                    $" Id {arregloCursos[contador].UniqueId}");
                contador++;
            } while (contador < arregloCursos.Length);
        }

        private static void ImprimirCursosFor(Curso[] arregloCursos)
        {
            for (int i = 0; i < arregloCursos.Length; i++)
            {
                Console.WriteLine($"Nombre {arregloCursos[i].Nombre} ," +
                    $" Id {arregloCursos[i].UniqueId}");
            }
        }

        private static void ImprimirCursosForEach(Curso[] arregloCursos)
        {
            foreach (var curso in arregloCursos)
            {
                Console.WriteLine($"Nombre {curso.Nombre} ," +
                    $" Id {curso.UniqueId}");
            }
        }
        */
    }

}
