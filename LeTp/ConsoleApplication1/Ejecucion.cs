using System;
using System.IO;
using System.Text;

namespace Charcito
{
    class Ejecucion
    {
        private string mensajito;
        public Ejecucion()
        {
            mensajito = "a";
        }
        public void InsertandoMensaje()
        {
            if (!(File.Exists("ElMensaje.txt")))
            {
                Console.WriteLine("Por favor, escriba un mensaje de bienvenida");
                mensajito = Console.ReadLine();
                Console.WriteLine("Guardando mensaje...");
                FileStream cosa = new FileStream("ElMensaje.txt", FileMode.Create, FileAccess.Write);
                if (cosa.CanWrite)
                {
                    byte[] bufferus = Encoding.ASCII.GetBytes(mensajito);
                    cosa.Write(bufferus, 0, bufferus.Length);
                }
                cosa.Flush();
                cosa.Close();
            }
        }
        public string LeyendoMensaje()
        {
            try
            {
                FileStream cosa = new FileStream("ElMensaje.txt", FileMode.Open, FileAccess.Read);
                byte[] bufferus = new byte[1024];
                int bytesread = cosa.Read(bufferus, 0, bufferus.Length);
                return Encoding.ASCII.GetString(bufferus, 0, bytesread);
            }
            catch (Exception e)
            {
                Console.WriteLine("no hay ningun mensaje");
                return "papapa";
            }
        }
    }
}
