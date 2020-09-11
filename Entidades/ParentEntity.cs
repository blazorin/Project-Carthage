using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Carthage.Entidades
{
    public abstract class ParentEntity
    {
        public string UniqueId { get; internal set; }
        public string Nombre { get; set; }

        public ParentEntity() => UniqueId = Guid.NewGuid().ToString();

        public override string ToString()
        {
            return $"{Nombre},{UniqueId}";
        }
    }
}
