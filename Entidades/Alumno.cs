using System;
using System.Collections.Generic;

namespace Project_Carthage.Entidades
{
    public class Alumno : ParentEntity
    {
        public Alumno() => UniqueId = Guid.NewGuid().ToString();
        public List<Evaluaciones> Evaluaciones { get; set; }
    }
}
