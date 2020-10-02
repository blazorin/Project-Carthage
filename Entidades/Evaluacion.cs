using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Project_Carthage.Entidades
{
    // [DebuggerDisplay("")]
    public class Evaluacion : ParentEntity
    {

        public Asignatura Asignatura { get; set; }

        public Alumno evOwner { get; set; }
        public float Nota { get; set; }

        public override string ToString()
        {
            return $"{Nota},{evOwner.Nombre}, {Asignatura.Nombre}";
        }
    }
}
