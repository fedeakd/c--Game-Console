using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilidadess
{
 public  class Objeto
    {
        protected char instintivo;
        protected Random random;
        protected int x;
        protected int y;
        public char Instintivo
        {
            get
            {

                return instintivo;
            }

            set
            {
                instintivo = value;
            }
        }
        public int PosY
        {
            get { return y; }
            set { y = value; }
        }

        public int PosX
        {
          
            get { return x; }
            set { x = value; }
        }
        public Objeto(int x, int y)
        {
            this.instintivo = '*';
            this.x = x;
            this.y = y;
        }
        public Random Ramdos { get {
                return random;

            } }
        public Objeto(int x1, int x2, int y1, int y2)
        {
            this.instintivo = '*';
            random = new Random();
            this.x = random.Next(x1, x2);
            this.y = random.Next(y1, y2);

        }


    }
}
