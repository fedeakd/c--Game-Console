using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilidadess
{
    public abstract class Nucleo
    {
        protected Random random; 
        protected const char Horizontal = '▄';
        protected const char Vertical = '█';
        protected string escribir;
        protected char caracter;
        protected DateTime tiempoDeInicio;
        protected StringBuilder mostrar;
        protected short cantidadDeObjetos;
        protected bool perdio;
        protected bool gano;
        protected int posx = 0;
        protected int posy = 0;
        protected int i = 0;
        protected int q = 0;
        protected List<Objeto> listaObjetos;
        protected List<Computadora> listaEnimigos;
        public bool Gano
        {
            get { return gano; }
            set { gano = value; }
        }
        public bool Perdio
        {
            get { return perdio; }
            set { perdio = value; }
        }
        public int posX
        {
            get
            {
                return posx;
            }

        }
        public int posY
        {
            get
            {
                return posy;
            }
        }
        public Nucleo(int ancho, int altura)
        {
            mostrar = new StringBuilder();
            listaEnimigos = new List<Computadora>();
            listaObjetos = new List<Objeto>();
            tiempoDeInicio = DateTime.Now;
            gano = false;
            perdio = false;
            this.posx = ancho;
            this.posy = altura;


        }

        public abstract void ImprimirJuego(Jugador jugador);
        protected void comprobarAproximacion(Jugador robocop)
        {
            if ((caracter == Horizontal)||(caracter== Vertical))
            {
                if (i == robocop.Y)
                {
                    if ((q - 1)== robocop.X)
                    {
                        robocop.RobAntesXMenor = true;
                        return;
                    }
                    if ((q + 1) == robocop.X)
                    {
                        robocop.RobAntesXMayor = true;
                        return;
                    }
                }
                if (q == robocop.X)
                {
                    if ((i - 1) == robocop.Y)
                    {
                        robocop.RobAntesYMenor = true;
                        return;
                    }
                    if ((i + 1) == robocop.Y)
                    {
                        robocop.RobAntesYMayor = true;
                        return;
                    }
                }
            }

        }
        protected virtual void ComprobarObjetos()
        {
            foreach (Objeto item in listaObjetos)
            {
                if ((q == item.PosX) && (i == item.PosY))
                {
                   this.caracter  = item.Instintivo;
                }
            }
        }
        protected virtual void ComprobarCompuAproximacion()
        {
            foreach (Computadora item in listaEnimigos)
            {

                if ((item.X == item.SeMueveSuperior) || (item.Y == item.SeMueveSuperior))
                {
                    item.Movimiento = -1;
                }
                if ((item.X == item.SeMueveInferior) || (item.Y == item.SeMueveInferior))
                {
                    item.Movimiento = 1;
                }
                if ((item.X == q) && (item.Y == i))
                {
                    this.caracter= item.Instintivo;
                }


            }
        }
        protected virtual void RectangulosHorinzontales(int cantidad,int distancia, int tamaño, int y1, int y2, int lugar, EPuerta puerta)
        {
            int aux = 0;
            int aux2 = tamaño;
            for (int h = 0; h <cantidad; h++)
            {
                if ((EPuerta.Abajo == puerta || EPuerta.Arriba == puerta))
                {
                    Rectangulo(y1, y2, aux, aux2, aux + lugar, puerta);
                }
                else
                {
                    Rectangulo(y1, y2, aux, aux2,y1+lugar, puerta);
                }

                aux += distancia + tamaño;
                aux2 += tamaño + distancia;
            }

        }
        protected virtual void RectangulosVerticales(int cantidad, int distancia, int tamaño, int x1, int x2, int lugar, EPuerta puerta)
        {
            int aux = 0;
            int aux2 = tamaño;
            for (int i = 0; i <cantidad; i++)
            {
                if ((EPuerta.Abajo == puerta) || (EPuerta.Arriba == puerta))
                {
                    Rectangulo( aux, aux2,x1,x2, x1+lugar, puerta);
                }
                else if ((EPuerta.Derecha == puerta) || (EPuerta.Izquierda == puerta))
                {
                    Rectangulo(aux, aux2, x1, x2, aux + lugar, puerta);


                }
                aux += distancia + tamaño;
                aux2 += tamaño + distancia;

            }

        }
        protected virtual void RectangulosVerticales(int y1, int cantidad, int distancia, int tamaño, int x1, int x2, int lugar, EPuerta puerta)
        {
            int aux = y1;
            int aux2 = tamaño;
            for (int i = 0; i < cantidad; i++)
            {
                if ((EPuerta.Abajo == puerta) || (EPuerta.Arriba == puerta))
                {
                    Rectangulo(aux, aux2+y1, x1, x2, x1 + lugar, puerta);
                }
                else if ((EPuerta.Derecha == puerta) || (EPuerta.Izquierda == puerta))
                {
                    Rectangulo(aux, aux2+y1, x1, x2, aux + lugar, puerta);


                }
                aux += distancia + tamaño;
                aux2 += tamaño + distancia;

            }

        }
        protected virtual bool ComprobarSiEstaAtrapado(Jugador robo)
        {
            foreach (Computadora item in listaEnimigos)
            {
                if (item.EnumLugar == ELugar.Horizontal)
                {
                    if ((robo.Y + item.Distancia >= item.Y) && (robo.Y -item.Distancia <= item.Y)&&((robo.X>=item.SeMueveInferior)&&(robo.X<=item.SeMueveSuperior)))
                        {
                            {
                                if ((item.Movimiento == 1) && (robo.X >= item.X))
                                {
                                    return true;
                                }
                                if ((item.Movimiento == -1) && (robo.X <= item.X))
                                {

                                    return true;
                                }
                            }
                    }
                }
                else
                {
                    if ((robo.X + item.Distancia >= item.X) && (robo.X - item.Distancia <= item.X)&&((robo.Y>=item.SeMueveInferior)&&(robo.Y<=item.SeMueveSuperior)))
                    {
                        if ((item.Movimiento == 1) && (robo.Y >= item.Y))
                        {
                            return true;
                        }
                        if ((item.Movimiento == -1) && (robo.Y <= item.Y))
                        {
                            return true;
                        }


                    }


                }
            }
            return false;

        }
        protected virtual void ComprobarSiAgarroObjeto(Jugador robo)
        {
            Objeto aux = null;
            foreach (Objeto item in listaObjetos)
            {
                if ((item.PosX == robo.X) && (item.PosY == robo.Y))
                {

                    aux = item;
                    robo.ObjetoEncontrados += 1;
                    break;

                }

            }
            if (((object)aux) != null)
            {
                listaObjetos.Remove(aux);
            }
        }
        protected void Rectangulo(int posY1, int posY2, int posX1, int posX2, int numPuerta, EPuerta puerta)
        {
            if ((i >= posY1) && (i <= posY2))
            {
                if (q == posX2)
                {
                    this.caracter= Vertical;
                    if (puerta == EPuerta.Derecha)
                    {

                        if ((i == numPuerta) && (posX2 < posx - 1))
                        {

                            this.caracter = ' ';
                        }
                     
                    }
                }

                if (q == posX1)
                {
                    this.caracter =Vertical;
                    if ((puerta == EPuerta.Izquierda)||(posX2>=posx-1))
                    {
                        if (i == numPuerta)
                        {

                            caracter = ' ';
                        }
                    }
                }


            }
            if ((q < posX2) && (q > posX1))
            {
                if (i == posY2)
                {
                    caracter= Horizontal;
                    if (puerta == EPuerta.Abajo)
                    {
                        if (q == numPuerta)
                        {

                           caracter =' ';
                        }
                    }
                }
                if (i == posY1)
                {
                    this.caracter=Horizontal ;
                    if (puerta == EPuerta.Arriba)
                    {
                        if (q == numPuerta)
                        {
                           caracter=' ';
                        }
                    }
                }
            }


        }
        protected virtual void Principio()
        {
            escribir = null;
            caracter = ' ';
            if ((q == 0) || (q == (posx - 1)))
            {
                caracter = Vertical;
            }
        }
        protected virtual void Final(Jugador jugador)
        {
            if ((jugador.X == q) && (jugador.Y == i))
            {
                caracter = 'ð';

            }
            if (escribir != null)
            {
                mostrar.AppendFormat("{0}", escribir);
            }
            else
            {
                mostrar.AppendFormat("{0}", caracter);
            }
        }
        protected virtual void ExtraAfuera(Jugador jugador)
        {
            ComprobarSiAgarroObjeto(jugador);
            if (jugador.ObjetoEncontrados == cantidadDeObjetos)
            {
                jugador.RecoleccionDeObjetos = true;
            }
            if (ComprobarSiEstaAtrapado(jugador))
            {
                perdio = true;
            }
            if (jugador.Estado)
            {
                foreach (Computadora item in listaEnimigos)
                {
                    if (item.EnumLugar == ELugar.Horizontal)
                    {
                        item.X += item.Movimiento;
                    }
                    else
                    {
                        item.Y += item.Movimiento;
                    }
                }

            }
        }
        protected virtual void AbrirPuerta(Jugador jugar)
        {
            if ((jugar.RecoleccionDeObjetos) && (this.i == 1) && (this.q == (posX - 1)))
            {
                escribir = "  <-- salida";
                caracter = ' ';
                if ((this.i == jugar.Y) && (this.q == jugar.X))
                {
                    gano = true;
                }
            }
        }
        public bool Arrancador()
        {
            int cont = 0;
            Console.WindowWidth = 100;
            Console.WindowHeight = 45;
          
            Jugador j = new Jugador(2,2, "lcdm");
            while ((!Perdio) && (!Gano))
            {
                if (cont % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                ImprimirJuego(j);

                Console.WriteLine("\nIndique hacia donde quiere mover el robot w.Arriba s.Abajo d.Derecha a.Izquierda 0.Salir");
                j.HacerJugada(char.ToLower(Console.ReadKey().KeyChar), this);
                Console.Clear();
                cont += 1;
            }
            Console.Clear();
            if (Perdio)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                ImprimirJuego(j);
                
                Console.WriteLine("Has  sido  atrapado,has perdiddo!!");
                Console.ReadLine();
                Console.Clear();
                return false;


            }
            else
            {
                return true;
            }

            

        }
    }
}
