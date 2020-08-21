using Project_Carthage.Entidades;
using System;
using System.Collections.Generic;
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
            
        }


        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            WriteLine(new String('=', 15));
            WriteLine("Cursos del Colegio");
            WriteLine(new String('=', 15));


            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre {curso.Nombre} ," + $" Id {curso.UniqueId}");
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
