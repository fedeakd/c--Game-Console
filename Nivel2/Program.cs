using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilidadess;
namespace Nivel2
{
    class Program
    {
        static void Main(string[] args)
        {
            int cont = 0;
            Console.WindowWidth = 100;
            Console.WindowHeight = 40;
            Principal nu = new Principal(40, 30);
            Jugador j = new Jugador(1, 1, "lcdm");
            while ((!nu.Perdio) && (!nu.Gano))
            { 
                nu.ImprimirJuego(j);

                Console.WriteLine("\nIndique hacia donde quiere mover el robot w.Arriba s.Abajo d.Derecha a.Izquierda 0.Salir");
                j.HacerJugada(char.ToLower(Console.ReadKey().KeyChar), nu);
                Console.Clear();
                cont += 1;

            }
            Console.WriteLine("Has perdido");
            Console.ReadLine();
        }
    }
}
