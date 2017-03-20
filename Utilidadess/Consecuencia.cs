using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilidadess
{
    public class Consecuencia:Objeto
    {
        private bool piso;
        private int barraX1;
        private int barraX2;
        private int barraY1;
        private int barraY2;
        private ELugar lugar;
        public int BarraX1 {
            get
            {
                return barraX1;
            }

        }
        public int BarraX2
        {
            get
            {
                return barraX2;
            }

        }
        public int BarraY1
        {
            get
            {
                return barraY1;
            }

        }
        public int BarraY2
        {
            get
            {
                return barraY2;
            }

        }


        public ELugar Lugar {
            get
            {
                return lugar;
            }


            set
            {
                lugar = value;
            }

        }
        public bool Piso {
            get
            {
                return piso;
            }

            set {
                piso = value;

            }
            }
        public Consecuencia(int x1,int x2,int y1,int y2) : base(x1, x2, y1, y2)
        {

        }
        public Consecuencia(int x,int y,char nombre,bool piso) : base(x, y)
        {
           
            this.piso =piso;
            base.instintivo = nombre;
        }
        public void darValoresBarra(int x1, int x2, int y1, int y2,ELugar lugar)
        {
            this.lugar = lugar;
            this.barraX1 = x1;
            this.barraX2 = x2;
            this.barraY1 = y1;
            this.barraY2 = y2;

        }

    }
}
