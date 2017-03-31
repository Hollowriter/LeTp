using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charcito
{
    class Personaje
    {
        private int _x;
        private int _y;
        private char _p;
        public Personaje()
        {
            _x = 0;
            _y = 0;
            _p = 'x';
        }
        public Personaje(int x, int y, char p)
        {
            _x = x;
            _y = y;
            _p = p;
        }
        public void Movimiento(ConsoleKeyInfo keyay)
        {
            switch (keyay.Key)
            {
                case ConsoleKey.W:
                    if (_y > 0)
                    {
                        _y--;
                    }
                    break;
                case ConsoleKey.S:
                    if (_y < 23)
                    {
                        _y++;
                    }
                    break;
                case ConsoleKey.A:
                    if (_x > 0)
                    {
                        _x--;
                    }
                    break;
                case ConsoleKey.D:
                    if (_x < 79)
                    {
                        _x++;
                    }
                    break;
                default:
                    return;
            }
        }
        public void Dibujar()
        {
            Console.Clear();
            Console.SetCursorPosition(_x, _y);
            Console.Write(GetP());
        }
        public void SetX(int x)
        {
            _x = x;
        }
        public void SetY(int y)
        {
            _y = y;
        }
        public void SetP(char p)
        {
            _p = p;
        }
        public int GetX()
        {
            return _x;
        }
        public int GetY()
        {
            return _y;
        }
        public char GetP()
        {
            return _p;
        }
    }
}
