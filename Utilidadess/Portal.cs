using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilidadess
{
   public class Portal:Objeto
    {
        private Objeto ir;
        public Objeto HaciaDonde {

            get {
                return ir;

            }  }


        public Random Random0
        {
            get { return random; }
            set { random = value; }
        }
        public Portal(int x1,int y1,int x2,int y2) : base(x1, y1)
        {
            ir = new Objeto(x2, y2);
            ir.Instintivo='@';

            instintivo = '▒';
        }

    }
}
