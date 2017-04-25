using System;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Charcito
{
    class Climatologo
    {
        public void LlamarAlClima()
        {
            string pato;
            try
            {
                WebRequest rq = WebRequest.Create("https://query.yahooapis.com/v1/public/yql?q=select%20item.condition.text%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22buenos%20aires%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");
                WebResponse rsp = rq.GetResponse();
                Stream thyStream = rsp.GetResponseStream();
                StreamReader read = new StreamReader(thyStream);
                JObject datos = JObject.Parse(read.ReadToEnd());
                pato = (string)datos["query"]["results"]["channel"]["item"]["condition"]["text"];
                switch (pato)
                {
                    case "Cloudy":
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "Sunny":
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    default:
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                }
            }
            catch
            {
                pato = "revisa la conexion, mientras tanto te cambio el color a amarillo";
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }
    }
}
