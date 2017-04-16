using System;

namespace Charcito
{
    class Menu
    {
        private ConsoleKeyInfo inputting;
        public bool ThyMenu()
        {
            Ejecucion mensajeado = new Ejecucion();
			HighScore points = new HighScore();
            mensajeado.InsertandoMensaje();
            Console.WriteLine(mensajeado.LeyendoMensaje());
            Console.WriteLine("***************************Charcito*****************************");
            Console.WriteLine("Presione J para jugar");
            Console.WriteLine("Presione S para salir");
			Console.WriteLine(" ");
            points.LeeElPuntaje();
            while (true)
            {
                inputting = Console.ReadKey();
                switch (inputting.Key)
                {
                    case ConsoleKey.J:
                        Console.Clear();
                        return false;
                        break;
                    case ConsoleKey.S:
                        return true;
                        break;
                    default:
                        Console.WriteLine("Por favor, ingrese alguna de las teclas indicadas");
                        break;
                }
            }
        }
    }
}
