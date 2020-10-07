using Project_Carthage.Entidades;
using Project_Carthage.App;
using Project_Carthage.Utils;
using System;
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

            AppDomain.CurrentDomain.ProcessExit += SeTermina;
            AppDomain.CurrentDomain.ProcessExit += (o, a) => Console.Write("Chau");
            AppDomain.CurrentDomain.ProcessExit += delegate (Object o, EventArgs a)
            {
                Console.Write("EXIT");
            };

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

            //ImprimirCursosEscuela(engine.Escuela);
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


            ImprimirDiccionario(obtainedDico, true);

            Reporteador reporteador = new Reporteador(obtainedDico);
            IEnumerable<Evaluacion> listaEvaluaciones = reporteador.GetListaEvaluaciones();
            var listaAsignaturas = reporteador.GetListaAsignaturas();
            var DicoAsignXEv = reporteador.GetDicoAsignXEv();
            var DicoPromXAsig = reporteador.GetPromedioAlumno();

            var MejoresAlumnos = reporteador.GetMejoresAlumnos(DicoPromXAsig);

            // default index is 5, change it to whatever you want except +- 2147483647

            foreach (var item in MejoresAlumnos)
            {
                Utils.Printer.WriteTitle($"Mejores {item.Value.Count()} Alumnos de {item.Key}");

                foreach (var bestAlumnoAsignatura in item.Value)
                {
                    WriteLine($"{bestAlumnoAsignatura.Nombre} -> {bestAlumnoAsignatura.Promedio}");
                }

            }


            var iLugarLista = from obj in parentEntities
                              where obj is iLugar
                              select (iLugar)obj;

            //engine.Escuela.LimpiarLugar();

            ConsolaMenusDialogs(1);



        }

        private static void SeTermina(object sender, EventArgs e)
        {
            Console.Write("Saliendo");
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

        public static void ConsolaMenusDialogs(int dialog)
        {

            switch (dialog)
            {
                case 1:
                    Console.WriteLine();
                    Printer.WriteTitle("Menu Principal");

                    SelectMainOptionConsola();

                    break;

                case 2:
                    Console.WriteLine();
                    Printer.WriteTitle("Evaluacion por terminal");

                    CrearEvaluacionConsola();

                    break;


                default:
                    WriteLine("Ha ocurrido un error");
                    Printer.DrawLine(10);

                    ConsolaMenusDialogs(1);
                    break;
            }

        }

        public static void SelectMainOptionConsola()
        {
            WriteLine("1 - Reporteador");
            WriteLine("2 - Crear una Evaluacion");

            Printer.DrawLine(10);
            Printer.Enter();

            string respuesta = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(respuesta))
            {
                WriteLine("El valor del nombre no puede estar vacío");
                Printer.DrawLine(10);

                SelectMainOptionConsola();

            }
            else if (respuesta == "1" || respuesta == "2")
            {
                WriteLine("Has elegido la opción " + respuesta);

                if (respuesta == "1")
                    ReporteadorPanelConsola();
                else
                    ConsolaMenusDialogs(2);
            }
            else
            {
                WriteLine("Escribe 1 o 2 para elegir una opción");
                Printer.DrawLine(10);

                SelectMainOptionConsola();
            }
        }

        public static void ReporteadorPanelConsola()
        {

        }

        public static void CrearEvaluacionConsola()
        {
            var newEval = new Evaluacion();
            string nombre, notastring;

            WriteLine("Escribe el nombre de la Evaluacion");
            nombre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                WriteLine("El valor del nombre no puede estar vacío");
                ConsolaMenusDialogs(2);
                return;
            }
            else
            {
                newEval.Nombre = nombre.ToLower();
                WriteLine("Has elegido " + newEval.Nombre + " para el nombre de la Evaluacion");
            }

            WriteLine("Escribe la nota de la Evaluación");
            Printer.Enter();
            notastring = Console.ReadLine();

            if (string.IsNullOrEmpty(notastring))
            {
                throw new ArgumentException("El valor de la nota no puede estar vacío");
            }
            else
            {
                try
                {
                    newEval.Nota = float.Parse(notastring);

                    if (newEval.Nota < 0 || newEval.Nota > 10)
                    {
                        throw new ArgumentOutOfRangeException("La nota debe estar entre el rango de 0 a 10");
                    }

                    WriteLine("Has elegido " + newEval.Nota + " para la nota de la Evaluacion");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    WriteLine("La nota no es un número válido");
                }

                finally
                {
                    WriteLine("Evaluacion por terminal finalizado");
                }
            }

        }

        private static void SeTermina(object sender, EventArgs e)
        {
            Console.Write("Saliendo");
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

                        case LLaveDiccionario.Escuela:

                            WriteLine("Escuela: " + val);
                            break;

                        case LLaveDiccionario.Alumno:
                            WriteLine("Alumno: " + val);
                            break;

                        case LLaveDiccionario.Asignatura:
                            WriteLine("Asignatura: " + val);
                            break;

                        case LLaveDiccionario.Curso:

                            if ((val as Curso) != null)
                            {
                                Curso cursotmp = (Curso)val;
                                WriteLine($"Curso: {cursotmp} , {cursotmp.Alumno.Count}");

                            }
                            break;

                        case LLaveDiccionario.Evaluacion:
                            if (imprimirEval)
                            {
                                WriteLine("Evaluacion: " + val);
                            }

                            break;

                        default:
                            WriteLine(val);
                            break;
                    }
                    /*
                    if (keyValPair.Key == LLaveDiccionario.Alumno)
                    {
                        List<Alumno> alumnosRec = (List<Alumno>)keyValPair.Value;
                        foreach (Alumno alum in alumnosRec)
                        {
                            WriteLine(alum.Nombre);
                        }
                    }
                    */

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
