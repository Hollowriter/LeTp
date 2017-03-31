using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charcito
{
    class Obstaculo
    {
        private int _x;
        private int _y;
        private char _c;
        private bool _colliding;
        public Obstaculo()
        {
            _x = 0;
            _y = 0;
            _c = 'x';
            _colliding = false;
        }
        public Obstaculo(int x, int y, char c)
        {
            _x = x;
            _y = y;
            _c = c;
            _colliding = false;
        }
        public void Chocar(Personaje jugadorcito)
        {
            if (jugadorcito.GetX() == _x && jugadorcito.GetY() == _y)
            {
                _colliding = true;
            }
        }
        public void Dibujito()
        {
            Console.SetCursorPosition(_x, _y);
            Console.Write(_c);
        }
        public void SetX(int x)
        {
            _x = x;
        }
        public void SetY(int y)
        {
            _y = y;
        }
        public void SetC(char c)
        {
            _c = c;
        }
        public void SetColliding(bool colliding)
        {
            _colliding = colliding;
        }
        public int GetX()
        {
            return _x;
        }
        public int GetY()
        {
            return _y;
        }
        public char GetC()
        {
            return _c;
        }
        public bool GetColliding()
        {
            return _colliding;
        }
    }
}
