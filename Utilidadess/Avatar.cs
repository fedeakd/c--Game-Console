using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilidadess
{
  public  class Avatar
    {

        protected int x;
        protected int y;
        protected bool robAntesXMayor;
        protected bool robAntesYMayor;
        protected bool robAntesXMenor;
        protected bool robAntesYMenor;
        protected string nombre;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
            }
        }
        public bool RobAntesXMayor
        {
            get
            {

                return robAntesXMayor;

            }
            set
            {
                robAntesXMayor = value;
            }
        }
        public bool RobAntesYMayor
        {
            get
            {

                return robAntesYMayor;

            }
            set
            {
                robAntesYMayor = value;
            }
        }
        public bool RobAntesXMenor
        {
            get
            {
                return robAntesXMenor;

            }
            set
            {
                robAntesXMenor = value;
            }
        }
        public bool RobAntesYMenor
        {
            get
            {
                return robAntesYMenor;

            }
            set
            {
                robAntesYMenor = value;
            }
        }

        public int X
        {

            get { return this.x; }
            set
            {
                this.x = value;
            }


        }
        public int Y
        {

            get { return this.y; }
            set
            {
                this.y = value;
            }

        }
        public void MoverALaDerecha()
        {
            this.x += 1;

        }
        public void MoverALAIzquierda()
        {
            this.x -= 1;

        }
        public void MoverAbajo()
        {
            this.y += 1;

        }
        public void MoverArriba()
        {
            this.y -= 1;

        }
        public Avatar()
        {
            this.robAntesXMayor = false;
            this.robAntesYMayor = false;
            this.robAntesYMenor = false;
            this.robAntesXMenor = false;
            this.x = 0;
            this.y = 0;
            this.nombre = "noName";
        }
        public Avatar(int x, int y, string nombre)
        {
            this.robAntesXMayor = false;
            this.robAntesYMayor = false;
            this.robAntesYMenor = false;
            this.robAntesXMenor = false;
            this.x = x;
            this.y = y;
            this.nombre = nombre;

        }



    }

}

