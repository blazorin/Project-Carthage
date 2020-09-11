using System;
using System.Collections.Generic;

namespace Project_Carthage.Entidades
{
    public class Alumno : ParentEntity
    {
        public List<Evaluacion> Evaluaciones { get; set; }
        
    }
}
