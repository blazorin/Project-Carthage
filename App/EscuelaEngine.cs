using Project_Carthage.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Carthage
{
    public class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {
        }

        public void Inicializar()
        {

            Escuela = new Escuela("Academia Kadik", 1998, TiposEscuela.Primaria,
            ciudad: "Boulogne-Billancourt", pais: "Francia");

            Escuela.Cursos = new List<Curso>
            {
                new Curso(){Nombre = "Curso 101", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "Curso 201", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "Curso 301", Jornada = TiposJornada.Tarde},
                new Curso(){Nombre = "Curso 404", Jornada = TiposJornada.Tarde},
                new Curso(){Nombre = "Curso 504", Jornada = TiposJornada.Noche}
            };

        }
    }
}
