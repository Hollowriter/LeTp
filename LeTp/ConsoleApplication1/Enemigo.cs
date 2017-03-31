using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charcito
{
   abstract class Enemigo
    {
        private int _x;
        private int _y;
        private int _timer;
        private char _e;
        private bool _collide;
        public Enemigo()
        {
            _x = 0;
            _y = 0;
            _timer = 0;
            _e = 'D';
            _collide = false;
        }
        public Enemigo(int x, int y, int timer, char e)
        {
            _x = x;
            _y = y;
            _e = e;
            _timer = timer;
            _collide = false;
        }
        public abstract void EnemyMovement();
        public void Crashing(Personaje personajito)
        {
            if (personajito.GetX() == _x && personajito.GetY() == _y)
            {
                _collide = true;
            }
        }
        public void SetX(int x)
        {
            _x = x;
        }
        public void SetY(int y)
        {
            _y = y;
        }
        public void SetTimer(int timer)
        {
            _timer = timer;
        }
        public void SetE(char e)
        {
            _e = e;
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
        public int GetTimer()
        {
            return _timer;
        }
        public char GetE()
        {
            return _e;
        }
        public bool GetCollide()
        {
            return _collide;
        }
    }
}
