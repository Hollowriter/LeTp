using System;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace LosLinks
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombreDeLaPelicula;
            string titulo;
            Console.WriteLine("Escriba el nombre de una pelicula");
            nombreDeLaPelicula = Console.ReadLine();
            try
            {
                WebRequest req = WebRequest.Create("http://www.omdbapi.com/?t= " + nombreDeLaPelicula);

                WebResponse respuesta = req.GetResponse();

                Stream stream = respuesta.GetResponseStream();

                StreamReader sr = new StreamReader(stream);

                JObject data = JObject.Parse(sr.ReadToEnd());

                titulo = (string)data["Year"];
            }
            catch
            {
                titulo = "Ha ocurrido un error. Verifique su conexion, por favor.";
            }

            Console.WriteLine(titulo);

            Console.ReadLine();
        }
    }
}
