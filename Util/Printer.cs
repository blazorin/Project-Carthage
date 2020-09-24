using System;
using static System.Console;

namespace Project_Carthage.Utils
{
    public static class Printer
    {
        public static void DrawLine(int tamaño = 15)
        {
            WriteLine(new String('=', tamaño));
        }

        public static void WriteTitle(string titulo)
        {
            var longitud = titulo.Length + 4;

            DrawLine(longitud);
            WriteLine($"| {titulo} |");
            DrawLine(longitud);
        }

        public static void Beeep(int hz = 2000, int time = 500, int cantidad = 1)
        {
            while (cantidad > 0)
            {
                //Console.Beep(hz, time);
                cantidad--;
            }

        }
    }
}
