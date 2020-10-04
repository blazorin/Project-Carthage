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
            var listaEvaluaciones = GetListaEvaluaciones();

            return (from Evaluacion ev in listaEvaluaciones
                    select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluacion>> GetDicoAsignXEv()
        {
            var dicoRta = new Dictionary<string, IEnumerable<Evaluacion>>();

            return dicoRta;
        }
    }
}
