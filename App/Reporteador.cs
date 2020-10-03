using System;
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
    }
}
