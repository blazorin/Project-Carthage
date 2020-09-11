using System;
using System.Collections.Generic;

namespace Project_Carthage.Entidades
{
    public class Curso : ParentEntity
    {
        public TiposJornada Jornada { get; set; }

        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumno { get; set; }
        
    }
}
