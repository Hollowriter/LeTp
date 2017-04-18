using System;

namespace Charcito
{
    class Dinero
    {
        private int _x;
        private int _y;
        private static int _pts;
        private char _c;
        private bool _collide;
        public Dinero()
        {
            _x = 0;
            _y = 0;
            _pts = 0;
            _c = '$';
            _collide = false;
        }
        public Dinero(int x, int y, int pts, char c)
        {
            _x = x;
            _y = y;
            _pts = pts;
            _c = c;
            _collide = false;
        }
        public void SetX(int x)
        {
            _x = x;
        }
        public void SetY(int y)
        {
            _y = y;
        }
        public void SetPts(int pts)
        {
            _pts = pts;
        }
        public void SetC(char c)
        {
            _c = c;
        }
        public void SetCollide(bool collide)
        {
            _collide = collide;
        }
        public int GetX()
        {
            return _x;
        }
        public int GetY()
        {
            return _y;
        }
        public int GetPts()
        {
            return _pts;
        }
        public char GetC()
        {
            return _c;
        }
        public bool GetCollide()
        {
            return _collide;
        }
        public void Agarrado(Personaje coso)
        {
            if (coso.GetX() == _x && coso.GetY() == _y && _collide == false)
            {
                _collide = true;
                _c = ' ';
                _pts++;
            }
        }
        public void DibujarDinero()
        {
            Console.SetCursorPosition(_x, _y);
            Console.Write(_c);
        }
    }
}
