using Project_Carthage.Entidades;
using System;

namespace Project_Carthage
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Academia Kadik", 1998, TiposEscuela.Primaria,
                ciudad: "Boulogne-Billancourt", pais: "Francia"
                );

            Console.WriteLine(escuela);

        }
    }
}
