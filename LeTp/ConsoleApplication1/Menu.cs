using System;

namespace Charcito
{
    class Menu
    {
        private ConsoleKeyInfo inputting;
        public bool ThyMenu()
        {
            Console.WriteLine("***************************Charcito*****************************");
            Console.WriteLine("Presione J para jugar");
            Console.WriteLine("Presione S para salir");
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
