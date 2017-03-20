using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilidadess
{
  public  class Computadora:Avatar
    {
        private int movimientos;
        private const char instintivo = '¥';
        private ELugar enumLugar;
        private int distancia;
        private int seMueveInferior;
        private int seMueveSuperior;

        public int SeMueveSuperior
        {
            get { return seMueveSuperior; }
            set { seMueveSuperior = value; }
        }

        public int SeMueveInferior
        {
            get { return seMueveInferior; }
            set { seMueveInferior = value; }
        }


        public int Distancia
        {
            get { return distancia; }
            set { distancia = value; }
        }


        public ELugar EnumLugar
        {
            get { return enumLugar; }
        }

        public char Instintivo
        {
            get
            {
                return instintivo;
            }



        }
        public int Movimiento
        {
            get
            {
                return movimientos;
            }
            set
            {
                movimientos = value;
            }
        }
        public Computadora(int x, int y, string nom, int movi, ELugar enumLugar) : base(x, y, nom)
        {
            this.distancia = 1;
            this.movimientos = movi;
            this.enumLugar = enumLugar;

        }
        public Computadora(int x, int y, int movi, ELugar enumLugar,int distancia,int  inferior,int superior) : this(x, y,"Vacio", movi, enumLugar)
        {
            this.seMueveInferior = inferior;
            this.seMueveSuperior = superior;
            this.distancia = distancia;
        }
        public Computadora() : base()
        {
            this.movimientos = 0;

        }
    }
}
