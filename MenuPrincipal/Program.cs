using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nivel1;
using Nivel2;
using Nivel3;
using Nivel4;
namespace MenuPrincipal
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Nivel1.Principal nivel1 = new Nivel1.Principal(30, 22);
                Nivel2.Principal nivel2 = new Nivel2.Principal(40, 30);
                Principal3 nivel3 = new Principal3(50, 35);
                Nivel4.Principal4 nivel4 = new Principal4(50, 40);
                
                if (nivel1.Arrancador())
                {
                    if (nivel2.Arrancador())
                    {
                        if (nivel3.Arrancador())
                        {
                            if (nivel4.Arrancador())
                            {

                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
