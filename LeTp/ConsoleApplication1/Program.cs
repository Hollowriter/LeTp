using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charcito
{
    class Program
    {
        static void Main(string[] args)
        {
            bool perdiste = false;
            Personaje pepito = new Personaje(5, 5, 'p');
            Enemigo[] horizontales = new EnemigoHorizontal[5];
            Enemigo[] verticales = new EnemigoVertical[3];
            Obstaculo[] obstaculos = new Obstaculo[6];
            ConsoleKeyInfo llave;
            Random dom = new Random();
            pepito.Dibujar();
            for (int h = 0; h < horizontales.Length; h++)
            {
                horizontales[h] = new EnemigoHorizontal(dom.Next(0, 79), dom.Next(0, 23), 0, '@');
                horizontales[h].DibujarEnemigos();
            }
            for (int v = 0; v < verticales.Length; v++)
            {
                verticales[v] = new EnemigoVertical(dom.Next(0, 79), dom.Next(0, 23), 0, '&');
                verticales[v].DibujarEnemigos();
            }
            for (int w = 0; w < obstaculos.Length; w++)
            {
                obstaculos[w] = new Obstaculo(dom.Next(0, 79), dom.Next(0, 23), 'x');
                obstaculos[w].Dibujito();
            }
            do
            {
                if (Console.KeyAvailable)
                {
                    llave = Console.ReadKey();
                    pepito.Movimiento(llave);
                }
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(false);
                }
                pepito.Dibujar();
                for (int h = 0; h < horizontales.Length; h++)
                {
                    horizontales[h].DibujarEnemigos();
                    horizontales[h].MovimientoEnemigo();
                    horizontales[h].Crashing(pepito);
                    if (perdiste == false)
                    {
                        perdiste = horizontales[h].GetCollide();
                    }
                }
                for (int v = 0; v < verticales.Length; v++)
                {
                    verticales[v].DibujarEnemigos();
                    verticales[v].MovimientoEnemigo();
                    verticales[v].Crashing(pepito);
                    if (perdiste == false)
                    {
                        perdiste = verticales[v].GetCollide();
                    }
                }
                for (int w = 0; w < obstaculos.Length; w++)
                {
                    obstaculos[w].Chocar(pepito);
                    obstaculos[w].Dibujito();
                    if (perdiste == false)
                    {
                        perdiste = obstaculos[w].GetColliding();
                    }
                }
                System.Threading.Thread.Sleep(100);
            } while (perdiste == false);
            Console.Clear();
            Console.WriteLine("Perdiste :D");
            Console.ReadKey();
        }
    }
}
