using Project_Carthage.Entidades;
using System;
using static System.Console;

namespace Project_Carthage
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Academia Kadik", 1998, TiposEscuela.Primaria,
                ciudad: "Boulogne-Billancourt", pais: "Francia");

            escuela.Cursos = new Curso[] {
                new Curso(){Nombre = "Curso 101"},
                new Curso(){Nombre = "Curso 201"},
                new Curso(){Nombre = "Curso 301"}
        };


            ImprimirCursosEscuela(escuela);
            
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

        private static void ImprimirCursosWhile(Curso[] arregloCursos)
        {
            int contador = 0;

            while (contador < arregloCursos.Length)
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
    }
}
