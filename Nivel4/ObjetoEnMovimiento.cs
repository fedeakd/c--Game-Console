using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilidadess;
namespace Nivel4
{
    public class ObjetoEnMovimiento:Objeto
    {
       
        private bool xMenor;
        private bool xMayor;
        private bool yMenor;
        private bool yMayor;
        public bool XMenor {
            get {
                return xMenor;

            }
            set
            {
                xMenor = value;
            }
        }
        public bool XMayor
        {
            get
            {
                return xMayor;

            }
            set
            {
                xMayor = value;
            }
        }
        public bool YMenor
        {
            get
            {
                return yMenor;

            }
            set
            {
                yMenor = value;
            }
        }
        public bool YMayor
        {
            get
            {
                return yMayor;


            }
            set
            {
                yMayor = value;
            }
        }

        public ObjetoEnMovimiento(int x,int y) : base(x, y)
        {
            random = new Random();
            
            base.instintivo = 'o';

        }
        public void darMovimiento(int yalto,int num)
        { 
           
            if ((num == 0)&&(!XMayor))
            {
         
                x -= 1;
               
            }
           else if ((num == 1)&&(!xMenor))
            {
        

                x += 1;
            }
           else if ((num == 2)&&(!yMayor)&&(y > 0))
            {
          
                y -= 1;
            }
            else if ((num == 3)&&(!yMenor)&&(y<yalto))
            {
          
              y += 1;
            }
            num = random.Next(0, 4);
        }
    }
}
