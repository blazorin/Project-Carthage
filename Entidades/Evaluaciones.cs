using System;
using System.Collections.Generic;

namespace Project_Carthage.Entidades
{
    public class Evaluaciones : ParentEntity
    {
        public Evaluaciones() => UniqueId = Guid.NewGuid().ToString();

        public Asignatura Asignatura { get; set; }
        public float Nota { get; set; }
    }
}
