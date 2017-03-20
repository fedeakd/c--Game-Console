using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nivel4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 100;
            Console.WindowHeight = 59;
            while (true)
            {
                Principal4 nuevo = new Principal4(50, 40);
                nuevo.Arrancador();

            }
        }
    }
}
