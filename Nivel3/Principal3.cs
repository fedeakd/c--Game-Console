using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilidadess;
namespace Nivel3
{
   public class Principal3 : Nucleo
    {
        private List<Consecuencia> listaDeConsecuencia;
        private List<Portal> listaPortal;
        public Principal3(int x, int y) : base(x, y)
        {
            random = new Random();
            listaPortal = new List<Portal>();
            listaDeConsecuencia = new List<Consecuencia>();
            AgregarPortal();
            AgregarConcecuencia();
            AgregarObjetos();
            AgregarEnemigos();


        }
        private void AgregarEnemigos()
        {
            //Parte de Arriba
           listaEnimigos.Add(new Computadora(1, 6, 1, ELugar.Horizontal, 1, 1, posX - 2));
           listaEnimigos.Add(new Computadora(30,0, 1, ELugar.Vertical, 1, 2,12));
           listaEnimigos.Add(new Computadora(23, 12, -1, ELugar.Vertical, 1, 0, 12));

            //Parte del medio
            listaEnimigos.Add(new Computadora(17,14, 1, ELugar.Vertical, 0, 14,20));
            listaEnimigos.Add(new Computadora(24,20, -1, ELugar.Vertical, 0, 14, 20));
            listaEnimigos.Add(new Computadora(30, 14, 1, ELugar.Vertical, 0, 14, 20));

            //Parte de abajo
            listaEnimigos.Add(new Computadora(1,28, 1, ELugar.Horizontal, 1, 1, posX - 2));
            listaEnimigos.Add(new Computadora(31,22, 1, ELugar.Vertical, 1, 22, 34));
            listaEnimigos.Add(new Computadora(24, 34, -1, ELugar.Vertical, 1, 22, 34));
       
        }
        private void AgregarObjetos()
        {
            int aux=0;
            int aux2= 0;
            int aux3 = 0;
            for (int p = 0; p < 2; p++)
            {
        
                for (int o = 0; o < 4; o++)
                {
                    listaObjetos.Add(new Objeto(4 + aux2, aux + 2));
                    aux += 8;
                    if ((o + 1) % 2 == 0)
                    {
                        aux =aux3;
                        aux2 += 40;
                    }
                }
                aux3 = 22;
                aux =aux3;
                aux2 = 0;
            }
            cantidadDeObjetos =(short) listaObjetos.Count;
        }
        private void AgregarConcecuencia()
        {
            listaDeConsecuencia.Add(new Consecuencia(11,17, '#', false));//a
            listaDeConsecuencia.Add(new Consecuencia(48, 17, '#', false));//b
            listaDeConsecuencia.Add(new Consecuencia(1, 33,'#',false));//d
            listaDeConsecuencia.Add(new Consecuencia(1, 23, '#', false));//c
            listaDeConsecuencia.Add(new Consecuencia(48,33, '#', false));//f

            listaDeConsecuencia[0].darValoresBarra(12,12,10, 10, ELugar.Vertical);//0
            listaDeConsecuencia[1].darValoresBarra(37,37, 10, 10, ELugar.Vertical);//1
            listaDeConsecuencia[2].darValoresBarra(37, 37, 24, 24,ELugar.Vertical);//2
            listaDeConsecuencia[3].darValoresBarra(12, 12, 32, 32, ELugar.Vertical);//3
            listaDeConsecuencia[4].darValoresBarra(12, 12,24, 24, ELugar.Vertical);///4




        }
        private void AgregarPortal()
        {
            listaPortal.Add(new Portal(posX - 2, 2, 2, 14));//a-1
            listaPortal.Add(new Portal(posX - 2, 2, 36, 14));//a-2
            listaPortal.Add(new Portal(posX - 2, 2, 39, 14));//a-3
            listaPortal.Add(new Portal(13, 14, 2, 3));//b-4
            listaPortal.Add(new Portal(2, 17, 2, 3));//c-4
            listaPortal.Add(new Portal(38, 17, 2, 3));//d-4
            listaPortal.Add(new Portal(48,23, 4, 9));
        }
        public override void ImprimirJuego(Jugador jugador)
        {

            jugador.RobAntesXMayor = false;
            jugador.RobAntesYMayor = false;
            jugador.RobAntesXMenor = false;
            jugador.RobAntesYMenor = false;

             mostrar = new StringBuilder();
            mostrar.Append("\t\t\t");
            for (this.i = 0; i < posX; i++)
            {
                mostrar.AppendFormat("{0}", Horizontal);
            }
            mostrar.Append("\n\t\t\t");
            for (this.i = 0; i < posy; i++)
            {

                for (this.q = 0; q < posx; q++)
                {
                    Principio();
                    RectangulosVerticales(2, 4, 4, 0, 12, 2, EPuerta.Derecha);
                    RectangulosVerticales(2, 4, 4, 37, posX - 1, 2, EPuerta.Izquierda);
                    RectangulosVerticales(22, 2, 4, 4, 0, 12, 2, EPuerta.Derecha);
                    RectangulosVerticales(22, 2, 4, 4, 37, posX - 1, 2, EPuerta.Izquierda);
                    RectangulosHorinzontales(2, 25, 12, 13, 21,10, EPuerta.Derecha);
                    DibujarBarra(13, 34, 13, ELugar.Horizontal);
                    DibujarBarra(15, 36,21, ELugar.Horizontal);
                    ComprobarObjetos();
                    ComprobarConsecuencia();
                    AbrirPuerta(jugador);
                    ComprobarCompuAproximacion();              
                    DibujarPortalOrigen();
                    comprobarAproximacion(jugador);
                    ExtraAdentro1();
                    Final(jugador);
                }
                mostrar.Append("\n\t\t\t");
            }
            Transportar(jugador);
           ExtraAfuera(jugador);
            ComprobarSiAgarroObjeto(jugador);
            for (int i = 0; i < posX; i++)
            {
                mostrar.AppendFormat("{0}", Horizontal);
            }
         
            Console.WriteLine(mostrar);
            jugador.Estado = false;
        }
        public void DibujarBarra(int pos1, int pos2, int aux, ELugar lugar)
        {
            if (lugar == ELugar.Horizontal)
            {
                if (((this.q >= pos1) && (this.q <= pos2)) && (aux == i))
                {
                    caracter = Horizontal;
                    return;
                }

            }
            else
            {
                if (((this.i >= pos1) && (this.i <= pos2)) && (aux == q))
                {
                    caracter = Vertical;
                    return;
                }
            }
        }
        protected override void ExtraAfuera(Jugador jugador)
        {
            if ((listaPortal[0].PosX == jugador.X) && (listaPortal[0].PosY == jugador.Y))
            {
                int num = random.Next(3);
                jugador.X = listaPortal[num].HaciaDonde.PosX;
                jugador.Y = listaPortal[num].HaciaDonde.PosY;
            }
            foreach (Consecuencia item in listaDeConsecuencia)
            {
                if ((jugador.X == item.PosX) && (jugador.Y == item.PosY))
                {
                    item.Piso = true;

                }
            }
            base.ExtraAfuera(jugador);
        }
        public void DibujarPortalOrigen()
        {
            foreach (Portal item in listaPortal)
            {
                if ((item.PosX == q) && (item.PosY == i))
                {
                    caracter = item.Instintivo;
                }
                if ((item.HaciaDonde.PosX == q) && (item.HaciaDonde.PosY == i))
                {
                    caracter = item.HaciaDonde.Instintivo;
                }

            }

        }
        public void ExtraAdentro1()
        {
            if ((!listaDeConsecuencia[0].Piso) || (!listaDeConsecuencia[1].Piso))
            {
                if (((q == 13) || (q == 14)) && (i == 21))
                {
                    caracter = Horizontal;
                }
                if (((q == 35)||(q==36)) && (i == 13))
                {
                    caracter = Horizontal;
                }
            }
        }

        public void Transportar(Jugador jugador)
        {
            for (int h = 3; h < listaPortal.Count; h++)
            {
                if ((listaPortal[h].PosX == jugador.X) && (listaPortal[h].PosY == jugador.Y)) {
                    jugador.X = listaPortal[h].HaciaDonde.PosX;
                    jugador.Y = listaPortal[h].HaciaDonde.PosY;
                }
            }
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
                        caracter = ' ';
                    }
                }
            }
        }
    }
}
