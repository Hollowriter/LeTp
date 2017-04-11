using System;

namespace Charcito
{
    class EnemigoHorizontal:Enemigo
    {
        public EnemigoHorizontal()
        {
            SetX(0);
            SetY(0);
            SetTimer(0);
            SetE('D');
            SetCollide(false);
        }
        public EnemigoHorizontal(int x, int y, int timer, char e)
        {
            SetX(x);
            SetY(y);
            SetE(e);
            SetTimer(timer);
            SetCollide(false);
        }
        public override void MovimientoEnemigo()
        {
            if (GetTimer() < 20 && GetX() < 79)
            {
                SetX(GetX() + 1);
            }
            else if (GetTimer() < 40 && GetX() > 0)
            {
                SetX(GetX() - 1);
            }
            else
            {
                SetX(GetX());
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
