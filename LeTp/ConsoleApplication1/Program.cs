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
            Obstaculo[] obstaculos = new Obstaculo[6];
            ConsoleKeyInfo llave;
            Random dom = new Random();
            pepito.Dibujar();
            for (int w = 0; w < obstaculos.Length; w++)
            {
                obstaculos[w] = new Obstaculo(dom.Next(0, 79), dom.Next(0, 23), 'x');
                obstaculos[w].Dibujito();
            }
            do
            {
                llave = Console.ReadKey();
                pepito.Movimiento(llave);
                pepito.Dibujar();
                for (int w = 0; w < obstaculos.Length; w++)
                {
                    obstaculos[w].Chocar(pepito);
                    obstaculos[w].Dibujito();
                    if (perdiste == false)
                    {
                        perdiste = obstaculos[w].GetColliding();
                    }
                }
            } while (perdiste == false);
            Console.Clear();
            Console.WriteLine("Perdiste :D");
            Console.ReadKey();
        }
    }
}
