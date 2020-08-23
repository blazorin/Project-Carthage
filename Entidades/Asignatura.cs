using System;

namespace Project_Carthage.Entidades
{
    public class Asignatura : ParentEntity
    {
        public Asignatura() => UniqueId = Guid.NewGuid().ToString();
    }
}
