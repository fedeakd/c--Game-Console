using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilidadess;
namespace Nivel2
{
   public class Principal:Nucleo,IAgregarEnemigosYObjetos
    {
        private List<Consecuencia> listaDeConsecuencia;
        public Principal(int x,int y) : base(x, y)
        {
            listaDeConsecuencia = new List<Consecuencia>();
            AgregarObjetos();
            AgregarConsecuencia();
            AgregarEnemigos();

        }
        public void AgregarConsecuencia()
        {
            listaDeConsecuencia.Add(new Consecuencia(38,28, '#',false));//1
            listaDeConsecuencia.Add(new Consecuencia(34, 10, '#',false));//2
            listaDeConsecuencia.Add(new Consecuencia(37, 18,'#',false));//3
            listaDeConsecuencia.Add(new Consecuencia(38,3, '#', true));//4
          
            listaDeConsecuencia[0].darValoresBarra(15, 15, 9,20,ELugar.Vertical);//c
            listaDeConsecuencia[1].darValoresBarra(34, 34, 16,16, ELugar.Horizontal);//a
            listaDeConsecuencia[2].darValoresBarra(10, 10, 25, 25, ELugar.Vertical);//d
            listaDeConsecuencia[3].darValoresBarra(1, 15, 20, 20, ELugar.Horizontal);//b
          

        }

        public void AgregarEnemigos()
        {
            listaEnimigos.Add(new Computadora(1, 7, 1, ELugar.Horizontal,1,1,posx-2));
            listaEnimigos.Add(new Computadora(1,22, 1, ELugar.Horizontal,1,1,posx-2));
            listaEnimigos.Add(new Computadora(16, 10, 1, ELugar.Vertical, 1, 10, 19));
            listaEnimigos.Add(new Computadora(23, 20, -1, ELugar.Vertical, 1, 10,19));
            listaEnimigos.Add(new Computadora(posX - 2,15, -1, ELugar.Horizontal,1, 16, posX - 2));
        }

        public void AgregarObjetos()
        {
            listaObjetos.Add(new Objeto(37, 12));
            listaObjetos.Add(new Objeto(37, 19));
            int aux = 0;
            int aux2 = 0;
            for (int p = 0; p < 4; p++)
            {
                listaObjetos.Add(new Objeto(5 + aux2, 5 + aux));
                aux += 20;
                if ((p + 1) % 2==0)
                {
                    aux = 0;
                    aux2 = 28;
                }

            }
            cantidadDeObjetos =(short) listaObjetos.Count;
        }

        public override void ImprimirJuego(Jugador jugador)
        {


            jugador.RobAntesXMayor = false;
            jugador.RobAntesYMayor = false;
            jugador.RobAntesXMenor = false;
            jugador.RobAntesYMenor = false;

            mostrar = new StringBuilder();
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
                    RectangulosVerticales(2,17, 6, 0, 10, 2, EPuerta.Derecha);
                    RectangulosVerticales(2, 17, 6,31,39,2, EPuerta.Derecha);
                    Rectangulo(9, 13, 32, 39, 2, EPuerta.Derecha);//sub cuadrado
                    Rectangulo(16,20, 32, 39, 2, EPuerta.Derecha);//sub cuadrado
                    Rectangulo(9, 20, 15, 39,2,EPuerta.Derecha);//cuadrado grande
                    ComprobarObjetos();
                    AbrirPuerta(jugador);
                    ComprobarConsecuencia();
                    OtrasComprobaciones();
                    ComprobarCompuAproximacion();
                    comprobarAproximacion(jugador);
                    Final(jugador);
         
              

                }
                mostrar.Append("\n\t\t\t\t");


            }
            for (int i = 0; i < posX; i++)
            {
                mostrar.AppendFormat("{0}", Horizontal);
            }
            ///Si El jugador esta en el #
            /// ExtraAfuera(jugador);
            ExtraAfuera(jugador);
       

            Console.WriteLine(mostrar);
            jugador.Estado = false;
        }
        protected override void ExtraAfuera(Jugador jugador)
        {
            foreach (Consecuencia item in listaDeConsecuencia)
            {
                if ((jugador.X == item.PosX) && (jugador.Y == item.PosY))
                {
                    item.Piso = true;

                }
            }
            //Extra
            if ((jugador.X == listaDeConsecuencia[3].PosX) && (jugador.Y == listaDeConsecuencia[3].PosY))
            {
                listaDeConsecuencia[1].Piso = false;
            }
            else
            {
                if ((listaDeConsecuencia[1].Piso) && (listaDeConsecuencia[2].Piso))
                {

                    listaDeConsecuencia[3].Piso = false;
                }
            }
            base.ExtraAfuera(jugador);
        }
        private void ComprobarConsecuencia()
        {
            foreach (Consecuencia item in listaDeConsecuencia)
            {
                if ((q == item.PosX) && (i == item.PosY))
                {
                    caracter = item.Instintivo;
                }
                if ((q >= item.BarraX1) && (q <= item.BarraX2) && (i >= item.BarraY1) && (i <= item.BarraY2))
                {
                    if (!item.Piso)
                    {
                        if (item.Lugar == ELugar.Vertical)
                        {
                            caracter = Vertical;
                        }
                        else
                        {
                            caracter = Horizontal;
                        }
                    }
                    else
                    {
                        caracter= ' ';
                    }
                }
            }
        }
        private void OtrasComprobaciones()
        {
            if (((q == 32) && (i == 11)))
            {
                caracter = ' ';
            }
            if(((q == 31) && (i == 2))&&(!listaDeConsecuencia[2].Piso))
            {
                caracter = Vertical;
            }
     
         
        }

    }
}
