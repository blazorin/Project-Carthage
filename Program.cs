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

            Dictionary<int, string> diccionario = new Dictionary<int, string>();

            diccionario.Add(1, "Franz");
            diccionario.Add(2, "Sissi");

            foreach (var keyValPair in diccionario)
            {
                WriteLine($"Key {keyValPair.Key} , {keyValPair.Value}");
            }

            Printer.WriteTitle("Diálogo");
            Dictionary<string, string> dico = new Dictionary<string, string>();

            dico.Add("Franz", "Franz Hopper, padre de Aelita y creador de Lyoko.");
            dico.Add("Aelita", "Hija de Franz Hopper.");
            dico.Add("Jeremy", "Estudiante de la academia " + engine.Escuela.Nombre + ".");

            foreach (KeyValuePair<string, string> keyValPair in dico)
            {
                //if (keyValPair.Key is string)
                WriteLine($"{keyValPair.Key}: {keyValPair.Value}");
            }

            Dictionary<LLaveDiccionario, IEnumerable<ParentEntity>> obtainedDico = engine.getObjectDictionary();


            ImprimirDiccionario(obtainedDico);

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

        public static void ImprimirDiccionario(Dictionary<LLaveDiccionario, IEnumerable<ParentEntity>> dico,
            bool imprimirEval = false
            )
        {

            foreach (var keyValPair in dico)
            {
                Printer.WriteTitle(keyValPair.Key.ToString());

                foreach (var val in keyValPair.Value)
                {
                    switch (keyValPair.Key)
                    {


                        default:
                            WriteLine(val);
                            break;
                    }

                }

                if (keyValPair.Key == LLaveDiccionario.Alumno)
                {
                    List<Alumno> alumnosRec = (List<Alumno>)keyValPair.Value;
                    foreach (Alumno alum in alumnosRec)
                    {
                        WriteLine(alum.Nombre);
                    }
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
