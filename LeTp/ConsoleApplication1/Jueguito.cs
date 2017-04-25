using System;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Charcito
{
    [Serializable]
    struct Position
    {
        public int x;
        public int y;
    }
    class Jueguito
    {
        bool perdiste = false;
        bool saliste = false;
        EstructuraDePosicion serializadorFeo = new EstructuraDePosicion();
        BinaryFormatter elFormatero = new BinaryFormatter();
        FileStream posicionamientoDelJugador;
        Personaje pepito;
        Position laPosicion;
        Menu superUI = new Menu();
		HighScore alto = new HighScore();
        Enemigo[] horizontales = new EnemigoHorizontal[5];
        Enemigo[] verticales = new EnemigoVertical[3];
        Obstaculo[] obstaculos = new Obstaculo[6];
        Dinero[] plata = new Dinero[6];
        Climatologo clima = new Climatologo();
        public void Jugar()
        {
            ConsoleKeyInfo llave;
            Random dom = new Random();
            perdiste = superUI.ThyMenu();
            clima.LlamarAlClima();
            // no funcionaba desde clases asi que la inicializacion la hice aca
            if (!File.Exists("Posicionamiento.txt"))
            {
                posicionamientoDelJugador = File.Create("Posicionamiento.txt");
                laPosicion.x = 5;
                laPosicion.y = 5;
            }
            else
            {
                using (posicionamientoDelJugador = File.OpenRead("Posicionamiento.txt"))
                {
                    laPosicion = (Position)elFormatero.Deserialize(posicionamientoDelJugador);
                }
            }
            posicionamientoDelJugador.Close();
            // no funcionaba desde clases asi que la inicializacion la hice aca
            pepito = new Personaje(laPosicion.x, laPosicion.y, 'p',10);
            // serializadorFeo.Posicionado(pepito, laPosicion);
            pepito.Dibujar();
            if (perdiste == false && saliste == false)
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
                for (int m = 0; m < plata.Length; m++)
                {
                    plata[m] = new Dinero(dom.Next(0, 79), dom.Next(0, 23), 0, '$');
                    plata[m].DibujarDinero();
                }
            }
            while (perdiste == false && saliste == false)
            {
                if (Console.KeyAvailable)
                {
                    llave = Console.ReadKey();
                    pepito.Movimiento(llave);
                    saliste = pepito.Salir(llave);
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
                    if (perdiste == false && saliste == false && pepito.GetHp() < 0)
                    {
                        perdiste = true;
                    }
                }
                for (int v = 0; v < verticales.Length; v++)
                {
                    verticales[v].DibujarEnemigos();
                    verticales[v].MovimientoEnemigo();
                    verticales[v].Crashing(pepito);
                    if (perdiste == false && saliste == false && pepito.GetHp() < 0)
                    {
                        perdiste = true;
                    }
                }
                for (int d = 0; d < plata.Length; d++)
                {
                    plata[d].Agarrado(pepito);
                    if (!(pepito.GetX() == plata[d].GetX() && pepito.GetY() == plata[d].GetY()))
                    {
                        plata[d].DibujarDinero();
                    }
                }
                for (int w = 0; w < obstaculos.Length; w++)
                {
                    obstaculos[w].Chocar(pepito);
                    obstaculos[w].Dibujito();
                    if (perdiste == false && saliste)
                    {
                        perdiste = obstaculos[w].GetColliding();
                    }
                }
                if (perdiste == true)
                {
                    Console.Clear();
                    Console.WriteLine("Perdiste :D");
                    System.Threading.Thread.Sleep(1000);
					alto.EscribiElPuntaje(plata[0].GetPts());
                }
                if (saliste == true)
                {
                    Console.Clear();
                    Console.WriteLine("¿Te vas tan pronto?");
                    Console.WriteLine("Para otra sera, jeje x3");
                    System.Threading.Thread.Sleep(1000);
                }
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Puntos: " + plata[0].GetPts());
                Console.WriteLine("Vidas: " + pepito.GetHp());
                System.Threading.Thread.Sleep(100);
            }
            Console.Clear();
            serializadorFeo.Guardado(pepito, laPosicion);
            Console.WriteLine("nos vemos c;");
            Console.ReadKey();
        }
    }
}
