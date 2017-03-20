using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilidadess;
namespace Nivel1
{
    public class Principal:Nucleo,IAgregarEnemigosYObjetos
    {
       
        public Principal(int x,int y) : base(x, y)
        {
            AgregarEnemigos();
            AgregarObjetos();
        }
     
        public void AgregarObjetos()
        {
            //Objeto son las bolita que usuario tiene que atrapar

            int y = 0;
            int x = 0;
            for (int i = 0; i < 6; i++)
            {
                listaObjetos.Add(new Objeto(1 + x, 12 + x, 1 + y, 4 + y));
                x += 17;
                if ((i + 1) % 2 == 0)
                {
                    x = 0;
                    y += 8;
                }
            }
            cantidadDeObjetos = (short)listaObjetos.Count;

        }
        public void AgregarEnemigos()
        {

            listaEnimigos.Add(new Computadora(1, 7, 1, ELugar.Horizontal,1,1,posx-2));
            listaEnimigos.Add(new Computadora(posX - 2, 15, -1, ELugar.Horizontal,1,1,posx-2));
        }
        public override void ImprimirJuego(Jugador jugador)
        {
            mostrar = new StringBuilder();
            jugador.RobAntesXMayor = false;
            jugador.RobAntesYMayor = false;
            jugador.RobAntesXMenor = false;
            jugador.RobAntesYMenor = false;
           
            mostrar.Append("\t\t\t\t");
            for (this.i = 0; i < posX; i++)
            {
                mostrar.AppendFormat("{0}", Horizontal);
            }
            mostrar.Append("\n\t\t\t\t");
            for (this.i = 0; i < posy; i++)
            {

                for (this.q = 0; q < posx; q++)
                {
                    Principio();
                    RectangulosVerticales(3, 3, 5, 0, 12, 2, EPuerta.Derecha);
                    RectangulosVerticales(3, 3, 5, 17, 29, 2, EPuerta.Derecha);
                    AbrirPuerta(jugador);
                    ComprobarCompuAproximacion();
                    ComprobarObjetos();
                    comprobarAproximacion(jugador);
                    Final(jugador);


                }
                mostrar.Append("\n\t\t\t\t");


            }
            for (int i = 0; i < posX; i++)
            {
                mostrar.AppendFormat("{0}", Horizontal);
            }
            ExtraAfuera(jugador);
            
            Console.WriteLine(mostrar);
            jugador.Estado = false;
        }

    }
}
