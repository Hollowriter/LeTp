using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charcito
{
    class EnemigoVertical:Enemigo
    {
        public EnemigoVertical()
        {
            SetX(0);
            SetY(0);
            SetTimer(0);
            SetE('D');
            SetCollide(false);
        }
        public EnemigoVertical(int x, int y, int timer, char e)
        {
            SetX(x);
            SetY(y);
            SetE(e);
            SetTimer(timer);
            SetCollide(false);
        }
        public override void MovimientoEnemigo()
        {
            if (GetTimer() < 20 && GetY() < 23)
            {
                SetY(GetY() + 1);
            }
            else if (GetTimer() < 40 && GetY() > 0)
            {
                SetY(GetY() - 1);
            }
            else
            {
                SetY(GetY());
            }
            if (GetTimer() < 40)
            {
                SetTimer(GetTimer() + 1);
            }
            else
            {
                SetTimer(0);
            }
        }
    }
}
