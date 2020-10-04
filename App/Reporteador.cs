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

        public Dictionary<string, IEnumerable<object>> GetPromedioAlumno()
        {
            var dicoRta = new Dictionary<string, IEnumerable<object>>();
            var dicoAsignXEv = GetDicoAsignXEv();

            foreach (var asignConEvaus in dicoAsignXEv)
            {
                var dummy = from eval in asignConEvaus.Value
                            select new
                            {
                                eval.evOwner.UniqueId,
                                NombreAlumno = eval.evOwner.Nombre,
                                NombreEval = eval.Nombre,
                                eval.Nota
                            };
            }

            return dicoRta;
        }
    }
}
