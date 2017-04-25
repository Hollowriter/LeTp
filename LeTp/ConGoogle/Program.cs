using System;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ConGoogle
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombreDeLaCiudad;
            string titulo;
            Console.WriteLine("Escriba el nombre de una ciudad");
            nombreDeLaCiudad = Console.ReadLine();
            WebRequest req = WebRequest.Create("https://maps.googleapis.com/maps/api/geocode/json?address= " + nombreDeLaCiudad);

            WebResponse respuesta = req.GetResponse();

            Stream stream = respuesta.GetResponseStream();

            StreamReader sr = new StreamReader(stream);

            JObject data = JObject.Parse(sr.ReadToEnd());

            titulo = (string)data["results"];
            /*Como results es un array, no se puede convertir a string.
             Y si le cambio la extencion por Array, no lo puede convertir a bytearray*/
           
            Console.WriteLine(titulo);

           // Console.WriteLine(sr.ReadToEnd());

            Console.ReadLine();
        }
    }
}
