﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charcito
{
    class Jueguito
    {
        bool perdiste = false;
        Personaje pepito = new Personaje(5, 5, 'p');
        Menu superUI = new Menu();
        Enemigo[] horizontales = new EnemigoHorizontal[5];
        Enemigo[] verticales = new EnemigoVertical[3];
        Obstaculo[] obstaculos = new Obstaculo[6];
        public void Jugar()
        {
            ConsoleKeyInfo llave;
            Random dom = new Random();
            perdiste = superUI.ThyMenu();
            pepito.Dibujar();
            if (perdiste == false)
            {
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
            }
            while (perdiste == false)
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
                if (perdiste == true)
                {
                    Console.Clear();
                    Console.WriteLine("Perdiste :D");
                    System.Threading.Thread.Sleep(1000);
                }
                System.Threading.Thread.Sleep(100);
            }
            Console.Clear();
            Console.WriteLine("nos vemos c;");
            Console.ReadKey();
        }
    }
}