using System;
using System.Linq;
using System.Collections.Generic;
using Project_Carthage.Entidades;

namespace Project_Carthage.App
{
    public class Reporteador
    {
        Dictionary<LLaveDiccionario, IEnumerable<ParentEntity>> _diccionario;

        public Reporteador(Dictionary<LLaveDiccionario, IEnumerable<ParentEntity>> diccionario)
        {
            if (diccionario is null)
            {
                throw new ArgumentNullException(nameof(diccionario));
            }

            _diccionario = diccionario;
        }

        public IEnumerable<Evaluacion> GetListaEvaluaciones()
        {

            if (_diccionario.TryGetValue(LLaveDiccionario.Evaluacion, out IEnumerable<ParentEntity> lista))
            {
                return lista.Cast<Evaluacion>();
            }
            {
                return new List<Evaluacion>();
                //throw new NullReferenceException(nameof(Escuela) + " is null");
            }

        }
        public IEnumerable<string> GetListaAsignaturas()
        {
            return GetListaAsignaturas(out var dummy);
        }

        public IEnumerable<string> GetListaAsignaturas(out IEnumerable<Evaluacion> listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluaciones();

            return (from Evaluacion ev in listaEvaluaciones
                    select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluacion>> GetDicoAsignXEv()
        {
            var dicoRta = new Dictionary<string, IEnumerable<Evaluacion>>();
            var listaAsignaturas = GetListaAsignaturas(out IEnumerable<Evaluacion> listaEvaluaciones);

            foreach (var asignatura in listaAsignaturas)
            {
                var evalAsig = from Evaluacion eval in listaEvaluaciones
                               where eval.Asignatura.Nombre == asignatura
                               select eval;

                dicoRta.Add(asignatura, evalAsig);

            }

            return dicoRta;
        }

        public Dictionary<string, IEnumerable<AlumnoCualificado>> GetPromedioAlumno()
        {
            var dicoRta = new Dictionary<string, IEnumerable<AlumnoCualificado>>();
            var dicoAsignXEv = GetDicoAsignXEv();

            foreach (var asignConEvaus in dicoAsignXEv)
            {
                var promAlum = from Evaluacion eval in asignConEvaus.Value
                               group eval by eval.evOwner.Nombre
                            into grupoEvalsAlumno
                               select new AlumnoCualificado
                               {
                                   Nombre = grupoEvalsAlumno.Key,
                                   Promedio = grupoEvalsAlumno.Average((Evaluacion evaluacion) => evaluacion.Nota)
                               };

                dicoRta.Add(asignConEvaus.Key, promAlum);
            }

            return dicoRta;
        }

        public Dictionary<string, IEnumerable<AlumnoCualificado>> GetMejoresAlumnos(Dictionary<string, IEnumerable<AlumnoCualificado>> AsignaturaAndPromedio, int index = 5)
        {
            Dictionary<string, IEnumerable<AlumnoCualificado>> dicoAsigsPromedios;
            var dicoRta = new Dictionary<string, IEnumerable<AlumnoCualificado>>();

            if (AsignaturaAndPromedio != null)
            {
                dicoAsigsPromedios = AsignaturaAndPromedio;
            }
            else
            {
                Console.Write(nameof(dicoAsigsPromedios) + "is null");
                dicoAsigsPromedios = new Dictionary<string, IEnumerable<AlumnoCualificado>>();
            }

            foreach (var AsignaturaAndPromediosElement in dicoAsigsPromedios)
            {
                var MejoresAlumnosAsignatura = (from AlumnoCualificado alumno in AsignaturaAndPromediosElement.Value
                                                orderby alumno.Promedio descending
                                                select alumno).Take(index);

                dicoRta.Add(AsignaturaAndPromediosElement.Key, MejoresAlumnosAsignatura);

            }

            return dicoRta;
        }
    }
}
