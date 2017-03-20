using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilidadess
{
   public class Jugador:Avatar
    {
        private bool estado;
        private bool reColectoLosObjeto;
        private TimeSpan tiempoFinal;
        private int identificador;

        public int Identificador
        {
            get { return identificador; }
            set { identificador = value; }
        }

        public TimeSpan TiempoFinal
        {

            get
            {
                return tiempoFinal;
            }
            set
            {
                tiempoFinal = value;
            }
        }

        public bool RecoleccionDeObjetos
        {
            get { return reColectoLosObjeto; }
            set { reColectoLosObjeto = value; }
        }

        private int objetoEncontrado;
        public int ObjetoEncontrados
        {
            get
            {
                return objetoEncontrado;

            }
            set
            {
                objetoEncontrado = value;
            }

        }
        public bool Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
            }
        }

        public Jugador(int x, int y, string nom) : base(x, y, nom)
        {
            objetoEncontrado = 0;
            estado = false;
            RecoleccionDeObjetos = false;
        }
        public Jugador() : base()
        {
            objetoEncontrado = 0;
            estado = false;
            RecoleccionDeObjetos = false;
            tiempoFinal = new TimeSpan();
        }




        public void HacerJugada(char jugada, Nucleo reji)
        {
            switch (jugada)
            {
                case 'w':
                    if (((this.y - 1) >= 0) && (!base.robAntesYMayor))
                    {
                        estado = true;
                        MoverArriba();
                    }
                    break;
                case 's':
                    if (((Y + 1) < reji.posY) && (!base.robAntesYMenor))
                    {
                        estado = true;
                        MoverAbajo();
                    }
                    break;
                case 'd':
                    if ((!base.robAntesXMenor))
                    {
                        estado = true;
                        MoverALaDerecha();
                    }

                    break;
                case 'a':
                    if ((!base.robAntesXMayor))
                    {
                        estado = true;
                        MoverALAIzquierda();

                    }
                    break;

            }

        }
    }

}

