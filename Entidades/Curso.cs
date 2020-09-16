using Project_Carthage.Utils;
using System;
using System.Collections.Generic;

namespace Project_Carthage.Entidades
{
    public class Curso : ParentEntity, iLugar
    {
        public TiposJornada Jornada { get; set; }

        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumno { get; set; }

        public string Direccion { get; set; }

        public void LimpiarLugar()
        {
            Printer.DrawLine();

            Console.WriteLine("Limpiando Curso...");
            Console.WriteLine($"Curso {Nombre} está limpio");
        }
    }
}
