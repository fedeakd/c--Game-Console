using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilidadess;
namespace Nivel4
{
   public class Principal4:Nucleo,IAgregarEnemigosYObjetos
    {
        protected List<ObjetoEnMovimiento> listaObjMovimiento;
        private List<Consecuencia> listaDeConsecuencia;
        private List<Portal> listaPortal;
        public Principal4(int x,int y) : base(x, y)
        {
            random = new Random();
            listaDeConsecuencia = new List<Consecuencia>();
            listaObjMovimiento = new List<ObjetoEnMovimiento>();
            listaPortal = new List<Portal>();
            AgregarPortal();
            AgregarObjetoEnMovimiento();
            AgregarEnemigos();
            AgregarConsecuencia();
            AgregarObjetos();
        }
        private void AgregarPortal()
        {
            listaPortal.Add(new Portal(2,15,2,18));
            listaPortal.Add(new Portal(29, 27,25, 32));
            listaPortal.Add(new Portal(25,posY-1, 3,10));
        }

        private void AgregarConsecuencia()
        {
            int num =0, num2 = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int q = 0; q < 3; q++)
                {
                    listaDeConsecuencia.Add(new Consecuencia((5+num),(17+ num2), '#', false));
                    num +=18;
                }
                num = 0;
                num2 += 13;
            };
            listaDeConsecuencia[0].darValoresBarra(38,38, 26, 26, ELugar.Horizontal);//a-abre f
            listaDeConsecuencia[1].darValoresBarra(20,20, 26,26, ELugar.Horizontal);//b- abre e
            listaDeConsecuencia[2].darValoresBarra(20,20,21,21, ELugar.Horizontal);//c abre b
            listaDeConsecuencia[3].darValoresBarra(38, 38,21,21, ELugar.Horizontal);//d abre c
            listaDeConsecuencia[4].darValoresBarra(44, 46,11,11, ELugar.Horizontal);//e abre g
            listaDeConsecuencia[5].darValoresBarra(2, 3, 26, 26, ELugar.Horizontal);//f -abre  d

        }

        public void AgregarEnemigos()
        {
            //Parte 1
            listaEnimigos.Add(new Computadora(17,12,-1, ELugar.Horizontal, 0,17,24));
            listaEnimigos.Add(new Computadora(26, 12, -1, ELugar.Horizontal, 0, 26, 33));
            listaEnimigos.Add(new Computadora(42,12,1, ELugar.Horizontal, 0,35,42));

            //Parte 2
           listaEnimigos.Add(new Computadora(1, 23, 1, ELugar.Horizontal, 0, 1, posX-2));
           listaEnimigos.Add(new Computadora(posX-2, 24, -1, ELugar.Horizontal, 0, 1, posX - 2));
            listaEnimigos.Add(new Computadora(16, 17, 1, ELugar.Vertical, 1, 17, 30));
            listaEnimigos.Add(new Computadora(33, 17, 1, ELugar.Vertical, 1, 17, 30));
        }

        public void AgregarObjetos()
        {
            int num = 0, num2 = 0;
            //Parte del medio
            for (int i = 0; i < 2; i++)
            {
                for (int q = 0; q < 3; q++)
                {
                    listaObjetos.Add(new Objeto((9 + num), (17 + num2)));
                    num += 18;
                }
                num = 0;
                num2 += 13;
            };
            //Pate de arriba
            listaObjetos.Add(new Objeto(4, 4));
            listaObjetos.Add(new Objeto(4,12));
            listaObjetos.Add(new Objeto(48,15));

            //Parte de abajo 
            listaObjetos.Add(new Objeto(1, 35));
            listaObjetos.Add(new Objeto(posx-2, 35));
            cantidadDeObjetos = (short)listaObjetos.Count;
            // throw new NotImplementedException();
        }
        public void AgregarObjetoEnMovimiento()
        {
            //Parte 1
            for (int i = 0; i <8; i++)
            {
                listaObjMovimiento.Add(new ObjetoEnMovimiento(12+(i*3), 7));
            }
            //Parte 2
            for (int i = 0; i <10; i++)
            {
                listaObjMovimiento.Add(new ObjetoEnMovimiento(9+(i*4), 15));
            }
            //Parte 3

            for (int i = 0; i <25; i++)
            {
                if (i % 2==0)
                {
                    listaObjMovimiento.Add(new ObjetoEnMovimiento(i + 14, 34));
                }
                else
                {
                    listaObjMovimiento.Add(new ObjetoEnMovimiento(i + 14, 36));
                }
            }


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
                    ComprobarCompuAproximacion();
                    
                    RectangulosHorinzontales(2, 39, 5, 33, 37, 2, EPuerta.Abajo);
                    RectangulosHorinzontales(3, 5, 13, 16, 21, 2, EPuerta.Abajo);
                    RectangulosHorinzontales(3, 5, 13, 26, 31, 2, EPuerta.Arriba);
                    RectangulosVerticales(2, 0, 8, 0, 10,1, EPuerta.Derecha);
                    DibujarLineas(0,7,14,5,6);
                    DibujarLineas(9,15, 16, 8, 4);
                    DibujarBarra(46, 48, 11, ELugar.Horizontal);
                    DibujarBarra(11, posx-4,8, ELugar.Horizontal);
                    DibujarBarra(10, posx - 2, 16, ELugar.Horizontal);
                    DibujarBarra(10, posx - 2, 31, ELugar.Horizontal);
                    DibujarPortalOrigen();
                    AbrirPuerta(jugador);
                    ComprobarObjetos();
                    ComprobarConsecuencia();
                    ComprobarObjEnMovimiento();
                    comprobarAproximacion(jugador);
                    Final(jugador);


                }
                mostrar.Append("\n\t\t\t\t");
            }
            for (int i = 0; i < posX; i++)
            {
                mostrar.AppendFormat("{0}", Horizontal);
            }
            
            Transportar(jugador);
            ExtraAfuera(jugador);
            DarMovimientoALaLista(jugador);
            Console.WriteLine(mostrar);
            jugador.Estado = false;

        }
        protected override void ExtraAfuera(Jugador jugador)
        {
           
            foreach (Consecuencia item in listaDeConsecuencia)
            {
                if ((jugador.X == item.PosX) && (jugador.Y == item.PosY))
                {
                    if (item.Piso)
                    {
                        item.Piso = false;
                    }
                    else
                    {

                        item.Piso = true;
                    }
          

                }
            }

            base.ExtraAfuera(jugador);  
        }
        public void Transportar(Jugador jugador)
        {
            for (int h = 0; h < listaPortal.Count; h++)
            {
                if ((listaPortal[h].PosX == jugador.X) && (listaPortal[h].PosY == jugador.Y))
                {
                    jugador.X = listaPortal[h].HaciaDonde.PosX;
                    jugador.Y = listaPortal[h].HaciaDonde.PosY;
                }
            }
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
        public void DibujarLineas(int x1,int x2,int aux,int distancia,int cantidad)
        {
            int a = x1, b = x2;
            for (int i = 0; i < cantidad; i++)
            {
                if (i % 2 == 0)
                {
                    DibujarBarra(x1, x2 - 1, aux, ELugar.Vertical);
                }
                else
                {
                    DibujarBarra(x1 + 1, x2, aux, ELugar.Vertical);
                    
                }
                aux += distancia+1;
            }

        }
        public void ComprobarObjEnMovimiento()
        {
            foreach (ObjetoEnMovimiento item in listaObjMovimiento )
            {
                if ((q == item.PosX) && (i == item.PosY))
                {
                    this.caracter = item.Instintivo;
                }

                if ((caracter == Horizontal) || (caracter == Vertical))
                {

                    if (i == item.PosY)
                    {
                        if ((q - 1) == item.PosX)
                        {
                           
                            item.XMenor = true;


                        }
                        if ((q + 1) == item.PosX)
                        {
                            
                            item.XMayor = true;
                    
                        }
                    }
                    if (q == item.PosX)
                    {
                        if ((i - 1) == item.PosY)
                        {
                            item.YMenor = true;
                         
                        }
                        if ((i + 1) == item.PosY)
                        {
                            item.YMayor = true;

                        }
                    }
                }
          

            }
        }
        public void DarMovimientoALaLista(Jugador j)
        {
            foreach (ObjetoEnMovimiento item in listaObjMovimiento)
            {
                if ((j.X == item.PosX) && (j.Y == item.PosY))
                {
                  
                    perdio = true;
                }
                
                item.darMovimiento(posY, random.Next(0, 5));
                item.XMayor = false;
                item.XMenor = false;
                item.YMenor = false;
                item.YMayor = false;

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
